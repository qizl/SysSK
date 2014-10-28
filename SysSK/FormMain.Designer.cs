namespace SysSK
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.plFoot = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.plBody = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxConfig = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtShortKeysSavePath = new System.Windows.Forms.TextBox();
            this.btnChooseShortKeysSavePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEnabledShortKeys = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvShortKeys = new System.Windows.Forms.DataGridView();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPublish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShortKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plFoot.SuspendLayout();
            this.plBody.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbxConfig.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // plFoot
            // 
            this.plFoot.Controls.Add(this.btnHelp);
            this.plFoot.Controls.Add(this.btnSubmit);
            this.plFoot.Controls.Add(this.btnCancel);
            this.plFoot.Controls.Add(this.btnOk);
            this.plFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plFoot.Location = new System.Drawing.Point(0, 412);
            this.plFoot.Name = "plFoot";
            this.plFoot.Size = new System.Drawing.Size(663, 46);
            this.plFoot.TabIndex = 0;
            // 
            // btnHelp
            // 
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHelp.Location = new System.Drawing.Point(565, 9);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(86, 28);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "帮助";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(473, 9);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(86, 28);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "应用";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(381, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(287, 9);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // plBody
            // 
            this.plBody.Controls.Add(this.tabControl1);
            this.plBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBody.Location = new System.Drawing.Point(0, 0);
            this.plBody.Name = "plBody";
            this.plBody.Size = new System.Drawing.Size(663, 412);
            this.plBody.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.tabControl1.Location = new System.Drawing.Point(8, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxConfig);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(639, 372);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbxConfig
            // 
            this.gbxConfig.Controls.Add(this.btnRestore);
            this.gbxConfig.Controls.Add(this.txtShortKeysSavePath);
            this.gbxConfig.Controls.Add(this.btnChooseShortKeysSavePath);
            this.gbxConfig.Controls.Add(this.label2);
            this.gbxConfig.Controls.Add(this.label1);
            this.gbxConfig.Controls.Add(this.cbxEnabledShortKeys);
            this.gbxConfig.Font = new System.Drawing.Font("Arial", 10F);
            this.gbxConfig.Location = new System.Drawing.Point(11, 20);
            this.gbxConfig.Name = "gbxConfig";
            this.gbxConfig.Size = new System.Drawing.Size(616, 341);
            this.gbxConfig.TabIndex = 0;
            this.gbxConfig.TabStop = false;
            this.gbxConfig.Text = "配置";
            // 
            // btnRestore
            // 
            this.btnRestore.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRestore.Location = new System.Drawing.Point(31, 160);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(172, 28);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "还原默认配置";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtShortKeysSavePath
            // 
            this.txtShortKeysSavePath.BackColor = System.Drawing.Color.White;
            this.txtShortKeysSavePath.Font = new System.Drawing.Font("Arial", 12F);
            this.txtShortKeysSavePath.Location = new System.Drawing.Point(43, 116);
            this.txtShortKeysSavePath.Name = "txtShortKeysSavePath";
            this.txtShortKeysSavePath.ReadOnly = true;
            this.txtShortKeysSavePath.Size = new System.Drawing.Size(473, 26);
            this.txtShortKeysSavePath.TabIndex = 3;
            // 
            // btnChooseShortKeysSavePath
            // 
            this.btnChooseShortKeysSavePath.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChooseShortKeysSavePath.Enabled = false;
            this.btnChooseShortKeysSavePath.Location = new System.Drawing.Point(522, 115);
            this.btnChooseShortKeysSavePath.Name = "btnChooseShortKeysSavePath";
            this.btnChooseShortKeysSavePath.Size = new System.Drawing.Size(86, 28);
            this.btnChooseShortKeysSavePath.TabIndex = 2;
            this.btnChooseShortKeysSavePath.Text = "浏览...";
            this.btnChooseShortKeysSavePath.UseVisualStyleBackColor = true;
            this.btnChooseShortKeysSavePath.Click += new System.EventHandler(this.btnChooseShortKeysSavePath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "快捷键命令保存路径：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Win + R 输入快捷键，点击确定即可打开绑定的应用";
            // 
            // cbxEnabledShortKeys
            // 
            this.cbxEnabledShortKeys.AutoSize = true;
            this.cbxEnabledShortKeys.Checked = true;
            this.cbxEnabledShortKeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEnabledShortKeys.Location = new System.Drawing.Point(15, 30);
            this.cbxEnabledShortKeys.Name = "cbxEnabledShortKeys";
            this.cbxEnabledShortKeys.Size = new System.Drawing.Size(97, 20);
            this.cbxEnabledShortKeys.TabIndex = 0;
            this.cbxEnabledShortKeys.Text = "启用快捷键";
            this.cbxEnabledShortKeys.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dgvShortKeys);
            this.tabPage2.Font = new System.Drawing.Font("Arial", 10F);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(639, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "快捷键";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 338);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(484, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "请注意，某些快捷键可能会与系统默认命令重复，请先验证快捷键是否可用。";
            // 
            // dgvShortKeys
            // 
            this.dgvShortKeys.AllowUserToAddRows = false;
            this.dgvShortKeys.AllowUserToDeleteRows = false;
            this.dgvShortKeys.AllowUserToResizeColumns = false;
            this.dgvShortKeys.AllowUserToResizeRows = false;
            this.dgvShortKeys.BackgroundColor = System.Drawing.Color.White;
            this.dgvShortKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShortKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmPublish,
            this.clmPath,
            this.clmShortKey,
            this.Column1});
            this.dgvShortKeys.Location = new System.Drawing.Point(11, 20);
            this.dgvShortKeys.Name = "dgvShortKeys";
            this.dgvShortKeys.RowHeadersVisible = false;
            this.dgvShortKeys.RowTemplate.Height = 23;
            this.dgvShortKeys.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvShortKeys.Size = new System.Drawing.Size(616, 311);
            this.dgvShortKeys.TabIndex = 0;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "名称";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            this.clmName.Width = 130;
            // 
            // clmPublish
            // 
            this.clmPublish.HeaderText = "发布者";
            this.clmPublish.Name = "clmPublish";
            this.clmPublish.ReadOnly = true;
            // 
            // clmPath
            // 
            this.clmPath.HeaderText = "路径";
            this.clmPath.Name = "clmPath";
            this.clmPath.ReadOnly = true;
            this.clmPath.Width = 250;
            // 
            // clmShortKey
            // 
            this.clmShortKey.HeaderText = "快捷键";
            this.clmShortKey.Name = "clmShortKey";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 1000;
            // 
            // FormMain
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(663, 458);
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.plFoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统快捷键";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.plFoot.ResumeLayout(false);
            this.plBody.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbxConfig.ResumeLayout(false);
            this.gbxConfig.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortKeys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plFoot;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel plBody;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox gbxConfig;
        private System.Windows.Forms.CheckBox cbxEnabledShortKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShortKeysSavePath;
        private System.Windows.Forms.Button btnChooseShortKeysSavePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.DataGridView dgvShortKeys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPublish;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShortKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}

