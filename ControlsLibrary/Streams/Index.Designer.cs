﻿
namespace ControlsLibrary.Streams
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
            this.tblControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panTop = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lstData = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSector = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFaculty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStream = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnContxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContxRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tblControls.SuspendLayout();
            this.panTop.SuspendLayout();
            this.contxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblControls
            // 
            this.tblControls.ColumnCount = 1;
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblControls.Controls.Add(this.btnAdd, 0, 0);
            this.tblControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.tblControls.Location = new System.Drawing.Point(898, 2);
            this.tblControls.Name = "tblControls";
            this.tblControls.RowCount = 1;
            this.tblControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblControls.Size = new System.Drawing.Size(127, 36);
            this.tblControls.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(119, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.AddEdit_Click);
            // 
            // panTop
            // 
            this.panTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panTop.Controls.Add(this.tblControls);
            this.panTop.Controls.Add(this.lbTitle);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Padding = new System.Windows.Forms.Padding(10, 2, 5, 2);
            this.panTop.Size = new System.Drawing.Size(1030, 40);
            this.panTop.TabIndex = 2;
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(50)))), ((int)(((byte)(120)))));
            this.lbTitle.Location = new System.Drawing.Point(10, 2);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(156, 36);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Forms";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstData
            // 
            this.lstData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colSector,
            this.colFaculty,
            this.colLevel,
            this.colStream});
            this.lstData.ContextMenuStrip = this.contxMain;
            this.lstData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstData.FullRowSelect = true;
            this.lstData.GridLines = true;
            this.lstData.HideSelection = false;
            this.lstData.Location = new System.Drawing.Point(0, 40);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(1030, 680);
            this.lstData.TabIndex = 3;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.View = System.Windows.Forms.View.Details;
            this.lstData.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstData_ItemSelectionChanged);
            this.lstData.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "#ID";
            // 
            // colSector
            // 
            this.colSector.Text = "Sector";
            // 
            // colFaculty
            // 
            this.colFaculty.Text = "Faculty";
            // 
            // colLevel
            // 
            this.colLevel.Text = "Level";
            // 
            // colStream
            // 
            this.colStream.Text = "Stream";
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
            this.btnContxNew.Image = ((System.Drawing.Image)(resources.GetObject("btnContxNew.Image")));
            this.btnContxNew.Name = "btnContxNew";
            this.btnContxNew.Size = new System.Drawing.Size(131, 26);
            this.btnContxNew.Text = "New";
            this.btnContxNew.Click += new System.EventHandler(this.btnContxNew_Click);
            // 
            // btnContxEdit
            // 
            this.btnContxEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnContxEdit.Image")));
            this.btnContxEdit.Name = "btnContxEdit";
            this.btnContxEdit.Size = new System.Drawing.Size(131, 26);
            this.btnContxEdit.Text = "Edit";
            this.btnContxEdit.Click += new System.EventHandler(this.AddEdit_Click);
            // 
            // btnContxRefresh
            // 
            this.btnContxRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnContxRefresh.Image")));
            this.btnContxRefresh.Name = "btnContxRefresh";
            this.btnContxRefresh.Size = new System.Drawing.Size(131, 26);
            this.btnContxRefresh.Text = "Refresh";
            this.btnContxRefresh.Click += new System.EventHandler(this.btnContxRefresh_Click);
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.panTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Index";
            this.Size = new System.Drawing.Size(1030, 720);
            this.Load += new System.EventHandler(this.Index_Load);
            this.SizeChanged += new System.EventHandler(this.Index_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Index_Paint);
            this.tblControls.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.contxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblControls;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ListView lstData;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colFaculty;
        private System.Windows.Forms.ContextMenuStrip contxMain;
        private System.Windows.Forms.ToolStripMenuItem btnContxNew;
        private System.Windows.Forms.ToolStripMenuItem btnContxEdit;
        private System.Windows.Forms.ToolStripMenuItem btnContxRefresh;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.ColumnHeader colSector;
        private System.Windows.Forms.ColumnHeader colStream;
    }
}
