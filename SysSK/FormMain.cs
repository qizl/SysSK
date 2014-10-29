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
            if (Common.Config.IsEnabled)
                this._regedit.AddSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);
            else
                this._regedit.RemoveSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);

            /*
             * 读取注册表应用列表，保存到内存变量
             */
            List<App> apps = this._regedit.ReadApps();
            foreach (var item in apps)
                if (Common.Config.ShortKeys.FirstOrDefault(s => s.Name == item.Name) == null)
                    Common.Config.ShortKeys.Add(item);

            /*
             * 从内存变量中加载应用列表及快捷键
             */
            this.dgvShortKeys.Rows.Clear();
            foreach (var app in Common.Config.ShortKeys)
                this.dgvShortKeys.Rows.Add(app.Name, app.Publisher, app.Location, app.ShortKey);

            /*
             * 更新配置
             */
            Common.Config.UpdateTime = DateTime.Now;
            Common.Config.Save(Common.ConfigPath);
        }

        private void btnChooseShortKeysSavePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    this.txtShortKeysSavePath.Text = dialog.SelectedPath;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Common.Config = Common.DefaultConfig.Clone() as Config;
            this.initialize();
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
                FileInfo file = new FileInfo(this.txtChooseApp.Text);
                string shortkey = file.Name.Split('.')[0];
                string appName = file.Name;
                string location = this.txtChooseApp.Text;

                if (Common.Config.ShortKeys.FirstOrDefault(s => s.Name == appName && s.Location == location) != null)
                {
                    MessageBox.Show("该应用已添加到快捷键列表！");
                }
                else
                {
                    Common.Config.ShortKeys.Add(new App() { Name = appName, Location = location, ShortKey = shortkey });
                    this.dgvShortKeys.Rows.Add(appName, string.Empty, location, shortkey);
                }
            }
        }

        private void loadChange()
        {
            List<App> apps = new List<App>();
            foreach (DataGridViewRow item in this.dgvShortKeys.Rows)
            {
                if (item.Cells[3].Value != null && !string.IsNullOrWhiteSpace(item.Cells[3].Value.ToString()))
                {
                    App app = new App()
                    {
                        Name = item.Cells[0].Value == null ? string.Empty : item.Cells[0].Value.ToString(),
                        Publisher = item.Cells[1].Value == null ? string.Empty : item.Cells[1].Value.ToString(),
                        Location = item.Cells[2].Value == null ? string.Empty : item.Cells[2].Value.ToString(),
                        ShortKey = item.Cells[3].Value == null ? string.Empty : item.Cells[3].Value.ToString(),
                    };
                    apps.Add(app);
                }
            }

            this.removeCmds(Common.Config.ShortKeys, apps);
            this.createCmds(Common.Config.ShortKeys, apps);

            Common.Config.ShortKeys.Clear();
            Common.Config.ShortKeys.AddRange(apps);

            Common.Config.IsEnabled = this.cbxEnabledShortKeys.Checked;
            if (Common.Config.IsEnabled)
                this._regedit.AddSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);
            else
                this._regedit.RemoveSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);

            Common.Config.ShortKeysFolder = this.txtShortKeysSavePath.Text;
        }
        private bool removeCmds(List<App> currentShortkeys, List<App> newshortKeys)
        {
            Cmds cmd = new Cmds();
            foreach (var item in currentShortkeys)
                if (newshortKeys.FirstOrDefault(k => k.Name == item.Name && k.Location == item.Location) == null)
                    cmd.RemoveCmd(item.ShortKey, Common.Config.ShortKeysFolder);

            return true;
        }
        private bool createCmds(List<App> currentShortkeys, List<App> newshortKeys)
        {
            Cmds cmd = new Cmds();
            foreach (var item in newshortKeys)
                cmd.CreateCmd(item.ShortKey, item.Location, Common.Config.ShortKeysFolder);

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
    }
}
