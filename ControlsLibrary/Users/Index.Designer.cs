
namespace ControlsLibrary.Users
{
    partial class Index
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnContxEnableDisable = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxView = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.contxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lstData = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnAddNew.Location = new System.Drawing.Point(20, 20);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(95, 45);
            this.btnAddNew.TabIndex = 9;
            this.btnAddNew.Text = "&New";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.AddEdit_Clicked);
            // 
            // btnContxEnableDisable
            // 
            this.btnContxEnableDisable.CheckOnClick = true;
            this.btnContxEnableDisable.Name = "btnContxEnableDisable";
            this.btnContxEnableDisable.Size = new System.Drawing.Size(136, 26);
            this.btnContxEnableDisable.Text = "Activate";
            this.btnContxEnableDisable.Click += new System.EventHandler(this.btnContxEnableDisable_Click);
            // 
            // btnContxRefresh
            // 
            this.btnContxRefresh.Image = global::ControlsLibrary.Properties.Resources.refresh_32;
            this.btnContxRefresh.Name = "btnContxRefresh";
            this.btnContxRefresh.Size = new System.Drawing.Size(136, 26);
            this.btnContxRefresh.Text = "Refresh";
            this.btnContxRefresh.Click += new System.EventHandler(this.btnContxRefresh_Click);
            // 
            // btnContxEdit
            // 
            this.btnContxEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnContxEdit.Image")));
            this.btnContxEdit.Name = "btnContxEdit";
            this.btnContxEdit.Size = new System.Drawing.Size(136, 26);
            this.btnContxEdit.Text = "Edit";
            this.btnContxEdit.Click += new System.EventHandler(this.AddEdit_Clicked);
            // 
            // btnContxView
            // 
            this.btnContxView.Image = ((System.Drawing.Image)(resources.GetObject("btnContxView.Image")));
            this.btnContxView.Name = "btnContxView";
            this.btnContxView.Size = new System.Drawing.Size(136, 26);
            this.btnContxView.Text = "View";
            // 
            // btnContxNew
            // 
            this.btnContxNew.Image = ((System.Drawing.Image)(resources.GetObject("btnContxNew.Image")));
            this.btnContxNew.Name = "btnContxNew";
            this.btnContxNew.Size = new System.Drawing.Size(136, 26);
            this.btnContxNew.Text = "New";
            this.btnContxNew.Click += new System.EventHandler(this.btnContxNew_Click);
            // 
            // contxMain
            // 
            this.contxMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContxNew,
            this.btnContxView,
            this.btnContxEdit,
            this.btnContxRefresh,
            this.toolStripSeparator1,
            this.btnContxEnableDisable});
            this.contxMain.Name = "contxMain";
            this.contxMain.Size = new System.Drawing.Size(137, 140);
            this.contxMain.Opening += new System.ComponentModel.CancelEventHandler(this.contxMain_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnPrint.Location = new System.Drawing.Point(121, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 45);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "&Export PDF";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lstData
            // 
            this.lstData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colFName,
            this.colGender,
            this.colPhone,
            this.colEmail,
            this.colAddress,
            this.colUserType,
            this.colUsername,
            this.colStatus,
            this.colReg});
            this.lstData.ContextMenuStrip = this.contxMain;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(20, 86);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(1034, 546);
            this.lstData.TabIndex = 8;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstData_ItemSelectionChanged);
            this.lstData.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "#ID";
            this.colID.Width = 43;
            // 
            // colFName
            // 
            this.colFName.Text = "Full Name";
            this.colFName.Width = 117;
            // 
            // colGender
            // 
            this.colGender.Text = "Gender";
            this.colGender.Width = 118;
            // 
            // colPhone
            // 
            this.colPhone.Text = "Phone";
            this.colPhone.Width = 131;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 79;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 137;
            // 
            // colUserType
            // 
            this.colUserType.Text = "User Type";
            this.colUserType.Width = 136;
            // 
            // colUsername
            // 
            this.colUsername.Text = "Username";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 128;
            // 
            // colReg
            // 
            this.colReg.Text = "Registered";
            this.colReg.Width = 106;
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstData);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Index";
            this.Size = new System.Drawing.Size(1074, 657);
            this.Load += new System.EventHandler(this.Index_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Index_Paint);
            this.contxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ToolStripMenuItem btnContxEnableDisable;
        private System.Windows.Forms.ToolStripMenuItem btnContxRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnContxEdit;
        private System.Windows.Forms.ToolStripMenuItem btnContxView;
        private System.Windows.Forms.ToolStripMenuItem btnContxNew;
        private System.Windows.Forms.ContextMenuStrip contxMain;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colGender;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colUserType;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colReg;
        private System.Windows.Forms.ColumnHeader colFName;
        private System.Windows.Forms.ColumnHeader colUsername;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
