using SysSK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Common.Config.UpdateTime = DateTime.Now;
            Common.Config.Save(Common.ConfigPath);
        }
        void initialize()
        {
            this.cbxEnabledShortKeys.Checked = Common.Config.IsEnabled;
            this.txtShortKeysSavePath.Text = Common.Config.ShortKeysFolder;

            List<App> apps = this._regedit.ReadApps();
            this.dgvShortKeys.Rows.Clear();
            foreach (var app in apps)
                this.dgvShortKeys.Rows.Add(app.Name, app.Publisher, app.Location, app.ShortKey);
        }

        private void btnChooseShortKeysSavePath_Click(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            Common.Config = Common.DefaultConfig.Clone() as Config;
            this.initialize();
        }

        private void btnChooseApp_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.saveChange())
                this.Close();
        }
        private void loadChange()
        {
            Common.Config.IsEnabled = this.cbxEnabledShortKeys.Enabled;
            Common.Config.ShortKeysFolder = this.txtShortKeysSavePath.Text;

            List<App> apps = new List<App>();
            foreach (DataGridViewRow item in this.dgvShortKeys.Rows)
            {
                if (!string.IsNullOrWhiteSpace(item.Cells[3].Value.ToString()))
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
            Common.Config.ShortKeys.Clear();
            Common.Config.ShortKeys.AddRange(apps);
        }
        private bool removeCmds()
        {
            return true;
        }
        private bool createCmds()
        {
            return true;
        }
        private bool saveChange()
        {
            this.loadChange();

            this.removeCmds();
            this.createCmds();

            return Common.Config.Save(Common.ConfigPath);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
