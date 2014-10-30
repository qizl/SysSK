using SysSK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SysSK
{
    public partial class FormMain : Form
    {
        private bool _isChanged
        {
            get
            {
                return this.btnSubmit.Enabled;
            }
            set
            {
                this.btnSubmit.Enabled = value;
            }
        }

        private Regedit _regedit = new Regedit();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.loadConfig();
            this.initialize();
        }
        void loadConfig()
        {
            Common.Config = Config.Load(Common.ConfigPath);
            if (Common.Config == null)
                Common.Config = Common.DefaultConfig.Clone() as Config;
        }
        void initialize()
        {
            this.cbxEnabledShortKeys.Checked = Common.Config.IsEnabled;
            this.txtShortKeysSavePath.Text = Common.Config.ShortKeysFolder;

            /*
             * 保存命令路径到系统环境变量Path中
             */
            if (Common.Config.CanRemoveCurrentFolder)
                if (Common.Config.IsEnabled)
                    this._regedit.AddSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);
                else
                    this._regedit.RemoveSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);

            /*
             * 读取注册表应用列表，保存到内存变量
             */
            List<Cmd> apps = this._regedit.ReadApps();
            foreach (var item in apps)
                if (Common.Config.ShortKeys.FirstOrDefault(s => s.Name == item.Name) == null)
                    Common.Config.ShortKeys.Add(item);

            /*
             * 从内存变量中加载应用列表及快捷键
             */
            this.dgvShortKeys.Rows.Clear();
            foreach (var app in Common.Config.ShortKeys)
                this.dgvShortKeys.Rows.Add(app.Name, app.Type, app.Location, app.ShortKey, app.Remark);

            /*
             * 更新配置
             */
            Common.Config.UpdateTime = DateTime.Now;
            Common.Config.Save(Common.ConfigPath);

            this._isChanged = false;
        }

        private void cbxEnabledShortKeys_CheckedChanged(object sender, EventArgs e)
        {
            this._isChanged = true;
        }

        private void txtShortKeysSavePath_TextChanged(object sender, EventArgs e)
        {
            this._isChanged = true;
        }
        private void btnChooseShortKeysSavePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Common.Config.CanRemoveCurrentFolder = !(this._regedit.IsValueInSystemEnvironmentVariable_Path(dialog.SelectedPath) && this.txtShortKeysSavePath.Text != dialog.SelectedPath);
                    this.txtShortKeysSavePath.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认还原配置与快捷键吗？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Common.Config = Common.DefaultConfig.Clone() as Config;
                this.initialize();

                this._isChanged = true;
            }
        }

        private void dgvShortKeys_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            this._isChanged = true;
        }

        private void btnChooseApp_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "请选择应用：";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                    this.txtChooseApp.Text = dialog.FileName;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtChooseApp.Text))
            {
                if (File.Exists(this.txtChooseApp.Text))
                {
                    FileInfo file = new FileInfo(this.txtChooseApp.Text);
                    string appName = file.Name;
                    string shortkey = file.Name.Split('.')[0];
                    string location = this.txtChooseApp.Text;

                    if (Common.Config.ShortKeys.FirstOrDefault(s => s.Type == AppTypes.App && s.Name == appName && s.Location == location) != null)
                    {
                        MessageBox.Show("该应用已添加到快捷键列表！");
                    }
                    else
                    {
                        Common.Config.ShortKeys.Add(new Cmd() { Name = appName, Type = AppTypes.App, Location = location, ShortKey = shortkey });
                        this.dgvShortKeys.Rows.Add(appName, AppTypes.App, location, shortkey);

                        this.txtChooseApp.ResetText();
                        this._isChanged = true;
                    }
                }
                else
                {
                    string appName = this.txtChooseApp.Text;
                    string shortkey = this.txtChooseApp.Text.Split('.')[0];

                    if (Common.Config.ShortKeys.FirstOrDefault(s => s.Type == AppTypes.Cmd && s.Name == appName) != null)
                    {
                        MessageBox.Show("该命令已添加到快捷键列表！");
                    }
                    else
                    {
                        Common.Config.ShortKeys.Add(new Cmd() { Name = appName, Type = AppTypes.Cmd, ShortKey = shortkey });
                        this.dgvShortKeys.Rows.Add(appName, AppTypes.Cmd, string.Empty, shortkey);

                        this.txtChooseApp.ResetText();
                        this._isChanged = true;
                    }
                }
            }
        }

        private void loadChange()
        {
            List<Cmd> apps = new List<Cmd>();
            foreach (DataGridViewRow item in this.dgvShortKeys.Rows)
            {
                if (item.Cells[3].Value != null && !string.IsNullOrWhiteSpace(item.Cells[3].Value.ToString()))
                {
                    Cmd app = new Cmd()
                    {
                        Name = item.Cells[0].Value == null ? string.Empty : item.Cells[0].Value.ToString(),
                        Type = item.Cells[1].Value == null ? AppTypes.Cmd : (AppTypes)Enum.Parse(typeof(AppTypes), item.Cells[1].Value.ToString()),
                        Location = item.Cells[2].Value == null ? string.Empty : item.Cells[2].Value.ToString(),
                        ShortKey = item.Cells[3].Value == null ? string.Empty : item.Cells[3].Value.ToString(),
                        Remark = item.Cells[4].Value == null ? string.Empty : item.Cells[4].Value.ToString(),
                    };
                    apps.Add(app);
                }
            }

            this.removeCmds(Common.Config.ShortKeys, apps);
            this.createCmds(Common.Config.ShortKeys, apps);

            Common.Config.ShortKeys.Clear();
            Common.Config.ShortKeys.AddRange(apps);

            Common.Config.IsEnabled = this.cbxEnabledShortKeys.Checked;
            if (Common.Config.CanRemoveCurrentFolder)
                if (Common.Config.IsEnabled)
                    this._regedit.AddSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);
                else
                    this._regedit.RemoveSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);

            Common.Config.ShortKeysFolder = this.txtShortKeysSavePath.Text;
        }
        private bool removeCmds(List<Cmd> currentShortkeys, List<Cmd> newshortKeys)
        {
            CmdControl cmd = new CmdControl();
            cmd.RemoveAll(Common.Config.ShortKeysFolder);
            foreach (var item in currentShortkeys)
                if (newshortKeys.FirstOrDefault(k => k.Name == item.Name && k.Location == item.Location) == null)
                    cmd.RemoveCmd(item, Common.Config.ShortKeysFolder);

            return true;
        }
        private bool createCmds(List<Cmd> currentShortkeys, List<Cmd> newshortKeys)
        {
            CmdControl cmd = new CmdControl();
            foreach (var item in newshortKeys)
                cmd.CreateCmd(item, Common.Config.ShortKeysFolder);

            return true;
        }
        private bool saveChange()
        {
            this.loadChange();

            return Common.Config.Save(Common.ConfigPath);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.saveChange())
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.saveChange())
            {
                this.btnSubmit.Enabled = false;
                this.initialize();
            }
        }
    }
}
