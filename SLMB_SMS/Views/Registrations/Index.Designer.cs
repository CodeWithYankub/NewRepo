
namespace SLMB_SMS.Views.Registrations
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
            this.lstData = new System.Windows.Forms.ListView();
            this.colstudentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFormId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colisReceipt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnContxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.panSearch = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbClear = new System.Windows.Forms.Label();
            this.contxMain.SuspendLayout();
            this.panSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstData
            // 
            this.lstData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colstudentId,
            this.colYear,
            this.colFormId,
            this.colisReceipt,
            this.colRdate});
            this.lstData.ContextMenuStrip = this.contxMain;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(17, 88);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(1153, 577);
            this.lstData.TabIndex = 9;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstData_ItemSelectionChanged);
            this.lstData.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
            // 
            // colstudentId
            // 
            this.colstudentId.Text = "Student ID";
            this.colstudentId.Width = 161;
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            this.colYear.Width = 188;
            // 
            // colFormId
            // 
            this.colFormId.Text = "Form";
            this.colFormId.Width = 218;
            // 
            // colisReceipt
            // 
            this.colisReceipt.Text = "Receipt No";
            this.colisReceipt.Width = 195;
            // 
            // colRdate
            // 
            this.colRdate.Text = "Date Registrated";
            this.colRdate.Width = 167;
            // 
            // contxMain
            // 
            this.contxMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContxNew,
            this.btnContxEdit,
            this.btnContxRefresh});
            this.contxMain.Name = "contxMain";
            this.contxMain.Size = new System.Drawing.Size(132, 82);
            this.contxMain.Opening += new System.ComponentModel.CancelEventHandler(this.contxMain_Opening);
            // 
            // btnContxNew
            // 
            this.btnContxNew.Image = global::SLMB_SMS.Properties.Resources.new_16;
            this.btnContxNew.Name = "btnContxNew";
            this.btnContxNew.Size = new System.Drawing.Size(131, 26);
            this.btnContxNew.Text = "New";
            this.btnContxNew.Click += new System.EventHandler(this.btnContxNew_Click);
            // 
            // btnContxEdit
            // 
            this.btnContxEdit.Image = global::SLMB_SMS.Properties.Resources.edit_16;
            this.btnContxEdit.Name = "btnContxEdit";
            this.btnContxEdit.Size = new System.Drawing.Size(131, 26);
            this.btnContxEdit.Text = "Edit";
            this.btnContxEdit.Click += new System.EventHandler(this.AddEdit_Clicked);
            // 
            // btnContxRefresh
            // 
            this.btnContxRefresh.Image = global::SLMB_SMS.Properties.Resources.refresh_32;
            this.btnContxRefresh.Name = "btnContxRefresh";
            this.btnContxRefresh.Size = new System.Drawing.Size(131, 26);
            this.btnContxRefresh.Text = "Refresh";
            this.btnContxRefresh.Click += new System.EventHandler(this.btnContxRefresh_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnAddNew.Image = global::SLMB_SMS.Properties.Resources.new_white_16;
            this.btnAddNew.Location = new System.Drawing.Point(17, 29);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(116, 38);
            this.btnAddNew.TabIndex = 10;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.AddEdit_Clicked);
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.BackColor = System.Drawing.Color.White;
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.tbSearch);
            this.panSearch.Controls.Add(this.lbClear);
            this.panSearch.Controls.Add(this.label1);
            this.panSearch.Location = new System.Drawing.Point(906, 32);
            this.panSearch.Name = "panSearch";
            this.panSearch.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.panSearch.Size = new System.Drawing.Size(264, 30);
            this.panSearch.TabIndex = 11;
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
            this.tbSearch.Size = new System.Drawing.Size(196, 23);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Text = "Search...";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Image = global::SLMB_SMS.Properties.Resources.search_16;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 22);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colID
            // 
            this.colID.Text = "#ID";
            // 
            // lbClear
            // 
            this.lbClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbClear.Image = global::SLMB_SMS.Properties.Resources.close_16;
            this.lbClear.Location = new System.Drawing.Point(232, 4);
            this.lbClear.Name = "lbClear";
            this.lbClear.Size = new System.Drawing.Size(28, 22);
            this.lbClear.TabIndex = 2;
            this.lbClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbClear.Visible = false;
            this.lbClear.Click += new System.EventHandler(this.lbClear_Click);
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panSearch);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.btnAddNew);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Index";
            this.Size = new System.Drawing.Size(1187, 688);
            this.Load += new System.EventHandler(this.Index_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Index_Paint);
            this.contxMain.ResumeLayout(false);
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader colstudentId;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.ColumnHeader colFormId;
        private System.Windows.Forms.ColumnHeader colisReceipt;
        private System.Windows.Forms.ColumnHeader colRdate;
        private System.Windows.Forms.ContextMenuStrip contxMain;
        private System.Windows.Forms.ToolStripMenuItem btnContxNew;
        private System.Windows.Forms.ToolStripMenuItem btnContxEdit;
        private System.Windows.Forms.ToolStripMenuItem btnContxRefresh;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.Label lbClear;
    }
}
