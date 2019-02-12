using EnjoyCodes.SysSK.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EnjoyCodes.SysSK
{
    public partial class FormMain : Form
    {
        #region Members
        private bool _hasChanged
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
        #endregion

        #region Structures
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Initializes
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.loadConfig(Common.ConfigPath);
            this.initialize();
        }
        void loadConfig(string path)
        {
            Common.Config = Config.Load(path);
            if (Common.Config == null)
            {
                // 读取默认配置
                Common.Config = Common.DefaultConfig.Clone() as Config;

                // 添加syssk快捷键
                Common.Config.ShortKeys.Add(new Cmd
                {
                    Name = Path.GetFileName(Assembly.GetExecutingAssembly().Location),
                    Type = AppTypes.App,
                    Location = Assembly.GetExecutingAssembly().Location,
                    ShortKey = "sk"
                });
            }

            if (!File.Exists(Common.Config.RunAsAministratorAppPath))
            {
                MessageBox.Show($"系统组件缺失！未找到：{new DirectoryInfo(Common.Config.RunAsAministratorAppPath).Name}");
            }
        }
        void initialize()
        {
            this.cbxEnabledShortKeys.Checked = Common.Config.IsEnabled;
            this.txtShortKeysSavePath.Text = Common.Config.ShortKeysFolder;
            this.cbxRequireAdmin.Enabled = false;

            if (!Directory.Exists(Common.Config.ShortKeysFolder))
            {
                Directory.CreateDirectory(Common.DefaultConfig.ShortKeysFolder);
                Common.Config.ShortKeysFolder = Common.DefaultConfig.ShortKeysFolder;
            }

            // 保存命令路径到系统环境变量Path中
            if (Common.Config.CanRemoveCurrentFolder)
                if (Common.Config.IsEnabled)
                    this._regedit.AddSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);
                else
                    this._regedit.RemoveSystemEnvironmentVariable_Path(Common.Config.ShortKeysFolder);

            // 读取注册表应用列表，保存到内存变量
            this._regedit.ReadApps().ForEach(m =>
            {
                if (File.Exists(m.Location) && !Common.Config.ShortKeys.Any(s => s.Location == m.Location))
                    Common.Config.ShortKeys.Add(m);
            });
            this.createCmds(Common.Config.ShortKeys);

            // 从内存变量中加载应用列表及快捷键
            this.dgvShortKeys.Rows.Clear();
            foreach (var app in Common.Config.ShortKeys)
                this.dgvShortKeys.Rows.Add(app.Name, app.Type, app.Location, app.ShortKey, app.Remark);

            // 更新配置
            Common.Config.UpdateTime = DateTime.Now;
            Common.Config.Save(Common.ConfigPath);

            this._hasChanged = false;
        }
        #endregion

        #region Methods Tab_Normal
        private void cbxEnabledShortKeys_CheckedChanged(object sender, EventArgs e)
        {
            this._hasChanged = true;
        }

        private void txtShortKeysSavePath_TextChanged(object sender, EventArgs e)
        {
            this._hasChanged = true;
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

                this._hasChanged = true;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "请选择要导入的系统快捷键配置文件：";
                dialog.Multiselect = false;
                dialog.Filter = "系统快捷键配置文件(*.xml)|*.xml";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Common.Config = Config.Load(dialog.FileName);
                    if (Common.Config != null)
                    {
                        this.initialize();
                        MessageBox.Show("导入成功！");
                    }
                    else
                        MessageBox.Show("错误的配置文件！");
                }
            }
        }
        #endregion

        #region Methods Tab_Shortkeys
        private void dgvShortKeys_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            this._hasChanged = true;
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
                    var file = new FileInfo(this.txtChooseApp.Text);
                    var appName = file.Name;
                    var shortkey = file.Name.Split('.')[0];
                    var location = this.txtChooseApp.Text;

                    if (Common.Config.ShortKeys.Any(s => s.RequireAdmin == this.cbxRequireAdmin.Checked && s.Location == location))
                    {
                        MessageBox.Show("该应用已添加到快捷键列表！");
                    }
                    else
                    {
                        var cmd = new Cmd
                        {
                            Name = appName,
                            Type = AppTypes.App,
                            RequireAdmin = this.cbxRequireAdmin.Checked,
                            Location = location,
                            ShortKey = shortkey
                        };
                        if (this.cbxRequireAdmin.Checked)
                        {
                            cmd.Type = AppTypes.Cmd;
                            cmd.Name = $"\"{Common.Config.RunAsAministratorAppPath}\" \"{location}\"";
                            cmd.Location = location;
                        }
                        Common.Config.ShortKeys.Add(cmd);
                        this.dgvShortKeys.Rows.Add(cmd.Name, cmd.Type, cmd.Location, cmd.ShortKey);

                        this.txtChooseApp.ResetText();
                        this._hasChanged = true;
                    }
                }
                else
                {
                    var appName = this.txtChooseApp.Text;
                    var shortkey = this.txtChooseApp.Text.Split('.')[0];

                    if (Common.Config.ShortKeys.Any(s => s.Type == AppTypes.Cmd && s.Name == appName))
                    {
                        MessageBox.Show("该命令已添加到快捷键列表！");
                    }
                    else
                    {
                        Common.Config.ShortKeys.Add(new Cmd
                        {
                            Name = appName,
                            Type = AppTypes.Cmd,
                            ShortKey = shortkey
                        });
                        this.dgvShortKeys.Rows.Add(appName, AppTypes.Cmd, string.Empty, shortkey);

                        this.txtChooseApp.ResetText();
                        this._hasChanged = true;
                    }
                }
            }
        }

        private void TxtChooseApp_TextChanged(object sender, EventArgs e)
        {
            // 判断是否允许勾选管理员复选框
            if (File.Exists(Common.Config.RunAsAministratorAppPath))
            {
                this.cbxRequireAdmin.Enabled = File.Exists(this.txtChooseApp.Text);
                if (!this.cbxRequireAdmin.Enabled)
                    this.cbxRequireAdmin.Checked = false;
            }
        }
        #endregion

        #region Methods SaveChanges
        private void loadChange()
        {
            var apps = new List<Cmd>();
            foreach (DataGridViewRow item in this.dgvShortKeys.Rows)
            {
                if (!string.IsNullOrWhiteSpace(item.Cells[3].Value?.ToString()))
                {
                    var app = new Cmd()
                    {
                        Name = item.Cells[0].Value?.ToString() ?? string.Empty,
                        Type = (AppTypes)Enum.Parse(typeof(AppTypes), item.Cells[1].Value?.ToString() ?? "cmd"),
                        Location = item.Cells[2].Value?.ToString() ?? string.Empty,
                        ShortKey = item.Cells[3].Value?.ToString() ?? string.Empty,
                        Remark = item.Cells[4].Value?.ToString() ?? string.Empty,
                    };
                    apps.Add(app);
                }
            }

            this.removeCmds(Common.Config.ShortKeys, apps);
            this.createCmds(apps);

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
        /// <summary>
        /// 移除快捷键为空的命令
        /// </summary>
        /// <param name="currentShortkeys"></param>
        /// <param name="newshortKeys"></param>
        /// <returns></returns>
        private bool removeCmds(List<Cmd> currentShortkeys, List<Cmd> newshortKeys)
        {
            var cmd = new CmdControl();
            cmd.RemoveAll(Common.Config.ShortKeysFolder);
            foreach (var item in currentShortkeys)
                if (!newshortKeys.Any(k => k.Name == item.Name && k.Location == item.Location))
                    cmd.RemoveCmd(item, Common.Config.ShortKeysFolder);

            return true;
        }
        /// <summary>
        /// 创建新命令
        /// </summary>
        /// <param name="newshortKeys"></param>
        /// <returns></returns>
        private bool createCmds(List<Cmd> newshortKeys)
        {
            var cmd = new CmdControl();
            foreach (var item in newshortKeys)
                cmd.CreateCmd(item, Common.Config.ShortKeysFolder);

            return true;
        }
        private bool saveChanges()
        {
            this.loadChange();

            return Common.Config.Save(Common.ConfigPath);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this._hasChanged)
            {
                if (this.saveChanges())
                    this.Close();
            }
            else
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.saveChanges())
            {
                this.btnSubmit.Enabled = false;
                this.initialize();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e) => Process.Start("http://enjoycodes.com/ViewNote/def5effa-de8d-4fd7-ae0e-5c710e38ddb5");
        #endregion
    }
}
