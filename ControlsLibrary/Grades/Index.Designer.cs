
namespace ControlsLibrary.Grades
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
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.panSearch = new System.Windows.Forms.Panel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnContxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxGenRes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.colAverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStudentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStudentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstData = new System.Windows.Forms.ListView();
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
            this.btnAddNew.Location = new System.Drawing.Point(18, 22);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(95, 45);
            this.btnAddNew.TabIndex = 9;
            this.btnAddNew.Text = "&New";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.AddNew_Clicked);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tbSearch.Location = new System.Drawing.Point(2, 4);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(258, 23);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.Text = "Search student...";
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.BackColor = System.Drawing.Color.White;
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.tbSearch);
            this.panSearch.Location = new System.Drawing.Point(904, 36);
            this.panSearch.Name = "panSearch";
            this.panSearch.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
            this.panSearch.Size = new System.Drawing.Size(264, 31);
            this.panSearch.TabIndex = 10;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // contxMain
            // 
            this.contxMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContxNew,
            this.btnContxRefresh,
            this.btnContxDelete,
            this.toolStripSeparator1,
            this.btnContxGenRes});
            this.contxMain.Name = "contxMain";
            this.contxMain.Size = new System.Drawing.Size(195, 114);
            // 
            // btnContxNew
            // 
            this.btnContxNew.Image = ((System.Drawing.Image)(resources.GetObject("btnContxNew.Image")));
            this.btnContxNew.Name = "btnContxNew";
            this.btnContxNew.Size = new System.Drawing.Size(194, 26);
            this.btnContxNew.Text = "New";
            // 
            // btnContxRefresh
            // 
            this.btnContxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnContxRefresh.Image")));
            this.btnContxRefresh.Name = "btnContxRefresh";
            this.btnContxRefresh.Size = new System.Drawing.Size(194, 26);
            this.btnContxRefresh.Text = "Refresh";
            this.btnContxRefresh.Click += new System.EventHandler(this.btnContxRefresh_Click);
            // 
            // btnContxDelete
            // 
            this.btnContxDelete.ForeColor = System.Drawing.Color.Red;
            this.btnContxDelete.Image = global::ControlsLibrary.Properties.Resources.delete_32;
            this.btnContxDelete.Name = "btnContxDelete";
            this.btnContxDelete.Size = new System.Drawing.Size(194, 26);
            this.btnContxDelete.Text = "Delete";
            this.btnContxDelete.Click += new System.EventHandler(this.btnContxDelete_Click);
            // 
            // btnContxGenRes
            // 
            this.btnContxGenRes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnContxGenRes.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnContxGenRes.Image = global::ControlsLibrary.Properties.Resources.generate_32;
            this.btnContxGenRes.Name = "btnContxGenRes";
            this.btnContxGenRes.Size = new System.Drawing.Size(194, 26);
            this.btnContxGenRes.Text = "Generate Result";
            this.btnContxGenRes.Click += new System.EventHandler(this.btnContxGenRes_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnPrint.Location = new System.Drawing.Point(119, 22);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 45);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "&Export PDF";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // colAverage
            // 
            this.colAverage.Text = "Average";
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            // 
            // colClass
            // 
            this.colClass.Text = "Class";
            // 
            // colStudentName
            // 
            this.colStudentName.Text = "Student Name";
            this.colStudentName.Width = 195;
            // 
            // colStudentID
            // 
            this.colStudentID.Text = "Student ID";
            this.colStudentID.Width = 209;
            // 
            // colId
            // 
            this.colId.Text = "#ID";
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            // 
            // lstData
            // 
            this.lstData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colStudentID,
            this.colStudentName,
            this.colClass,
            this.colYear,
            this.colAverage,
            this.colRemarks});
            this.lstData.ContextMenuStrip = this.contxMain;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(18, 86);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(1150, 580);
            this.lstData.TabIndex = 8;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstData_ItemSelectionChanged);
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.panSearch);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstData);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Index";
            this.Size = new System.Drawing.Size(1187, 688);
            this.Load += new System.EventHandler(this.Index_Load);
            this.SizeChanged += new System.EventHandler(this.Index_SizeChanged);
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            this.contxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnContxRefresh;
        private System.Windows.Forms.ToolStripMenuItem btnContxNew;
        private System.Windows.Forms.ContextMenuStrip contxMain;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader colAverage;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.ColumnHeader colClass;
        private System.Windows.Forms.ColumnHeader colStudentName;
        private System.Windows.Forms.ColumnHeader colStudentID;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ToolStripMenuItem btnContxGenRes;
        private System.Windows.Forms.ToolStripMenuItem btnContxDelete;
    }
}
