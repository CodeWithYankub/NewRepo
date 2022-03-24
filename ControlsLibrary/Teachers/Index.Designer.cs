
namespace ControlsLibrary.Teachers
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbClear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panSearch = new System.Windows.Forms.Panel();
            this.btnContxLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.contxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lstData = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSectorID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPinCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coluApproved = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNextOfKing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panSearch.SuspendLayout();
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
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbSearch.Location = new System.Drawing.Point(36, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(199, 23);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Text = "Search id...";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // lbClear
            // 
            this.lbClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbClear.Location = new System.Drawing.Point(235, 4);
            this.lbClear.Name = "lbClear";
            this.lbClear.Size = new System.Drawing.Size(22, 23);
            this.lbClear.TabIndex = 2;
            this.lbClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClear.Visible = false;
            this.lbClear.Click += new System.EventHandler(this.lbClear_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 23);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.BackColor = System.Drawing.Color.White;
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.tbSearch);
            this.panSearch.Controls.Add(this.lbClear);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Location = new System.Drawing.Point(906, 34);
            this.panSearch.Name = "panSearch";
            this.panSearch.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.panSearch.Size = new System.Drawing.Size(261, 31);
            this.panSearch.TabIndex = 10;
            // 
            // btnContxLeft
            // 
            this.btnContxLeft.CheckOnClick = true;
            this.btnContxLeft.Name = "btnContxLeft";
            this.btnContxLeft.Size = new System.Drawing.Size(131, 26);
            this.btnContxLeft.Text = "Left?";
            this.btnContxLeft.Click += new System.EventHandler(this.btnContxLeft_Click_1);
            // 
            // btnContxRefresh
            // 
            this.btnContxRefresh.Image = global::ControlsLibrary.Properties.Resources.refresh_32;
            this.btnContxRefresh.Name = "btnContxRefresh";
            this.btnContxRefresh.Size = new System.Drawing.Size(131, 26);
            this.btnContxRefresh.Text = "Refresh";
            this.btnContxRefresh.Click += new System.EventHandler(this.btnContxRefresh_Click);
            // 
            // btnContxEdit
            // 
            this.btnContxEdit.Image = global::ControlsLibrary.Properties.Resources.edit_32;
            this.btnContxEdit.Name = "btnContxEdit";
            this.btnContxEdit.Size = new System.Drawing.Size(131, 26);
            this.btnContxEdit.Text = "Edit";
            this.btnContxEdit.Click += new System.EventHandler(this.AddEdit_Clicked);
            // 
            // btnContxNew
            // 
            this.btnContxNew.Image = global::ControlsLibrary.Properties.Resources.add_32;
            this.btnContxNew.Name = "btnContxNew";
            this.btnContxNew.Size = new System.Drawing.Size(131, 26);
            this.btnContxNew.Text = "New";
            this.btnContxNew.Click += new System.EventHandler(this.btnContxNew_Click);
            // 
            // contxMain
            // 
            this.contxMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContxNew,
            this.btnContxEdit,
            this.btnContxRefresh,
            this.toolStripSeparator1,
            this.btnContxLeft});
            this.contxMain.Name = "contxMain";
            this.contxMain.Size = new System.Drawing.Size(132, 114);
            this.contxMain.Opening += new System.ComponentModel.CancelEventHandler(this.contxMain_Opening);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnPrint.Location = new System.Drawing.Point(121, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(118, 45);
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
            this.colName,
            this.colGender,
            this.colPhone,
            this.colAdd,
            this.colEmail,
            this.colSectorID,
            this.colPinCode,
            this.coluApproved,
            this.colNextOfKing,
            this.colActive});
            this.lstData.ContextMenuStrip = this.contxMain;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(20, 85);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(1147, 577);
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
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 131;
            // 
            // colGender
            // 
            this.colGender.Text = "Gender";
            this.colGender.Width = 79;
            // 
            // colPhone
            // 
            this.colPhone.Text = "Phone";
            this.colPhone.Width = 128;
            // 
            // colAdd
            // 
            this.colAdd.Text = "Address";
            this.colAdd.Width = 136;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 137;
            // 
            // colSectorID
            // 
            this.colSectorID.Text = "Sector";
            this.colSectorID.Width = 117;
            // 
            // colPinCode
            // 
            this.colPinCode.Text = "Pin Code";
            this.colPinCode.Width = 118;
            // 
            // coluApproved
            // 
            this.coluApproved.Text = "Approved";
            this.coluApproved.Width = 87;
            // 
            // colNextOfKing
            // 
            this.colNextOfKing.Text = "Kin Name";
            this.colNextOfKing.Width = 106;
            // 
            // colActive
            // 
            this.colActive.Text = "Active";
            this.colActive.Width = 96;
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.panSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstData);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Index";
            this.Size = new System.Drawing.Size(1187, 688);
            this.Load += new System.EventHandler(this.Index_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Index_Paint);
            this.DoubleClick += new System.EventHandler(this.Index_DoubleClick);
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            this.contxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lbClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.ToolStripMenuItem btnContxLeft;
        private System.Windows.Forms.ToolStripMenuItem btnContxRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnContxEdit;
        private System.Windows.Forms.ToolStripMenuItem btnContxNew;
        private System.Windows.Forms.ContextMenuStrip contxMain;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colPinCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colGender;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colAdd;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colNextOfKing;
        private System.Windows.Forms.ColumnHeader coluApproved;
        private System.Windows.Forms.ColumnHeader colActive;
        private System.Windows.Forms.ColumnHeader colSectorID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
