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
            this.initialize();
        }
        void initialize()
        {
            List<App> apps = this._regedit.ReadApps();
            this.dgvShortKeys.Rows.Clear();
            foreach (var app in apps)
                this.dgvShortKeys.Rows.Add(app.Name, app.Publisher, app.Location, app.ShortKey);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseShortKeysSavePath_Click(object sender, EventArgs e)
        {

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {

        }
    }
}
