
namespace ControlsLibrary
{
    partial class Academics
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
            this.tblCntrolsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tblCntrolsLayout
            // 
            this.tblCntrolsLayout.ColumnCount = 2;
            this.tblCntrolsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCntrolsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCntrolsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCntrolsLayout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblCntrolsLayout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblCntrolsLayout.Location = new System.Drawing.Point(0, 0);
            this.tblCntrolsLayout.Name = "tblCntrolsLayout";
            this.tblCntrolsLayout.RowCount = 4;
            this.tblCntrolsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCntrolsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCntrolsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCntrolsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCntrolsLayout.Size = new System.Drawing.Size(1035, 668);
            this.tblCntrolsLayout.TabIndex = 1;
            // 
            // Academics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblCntrolsLayout);
            this.Name = "Academics";
            this.Size = new System.Drawing.Size(1035, 668);
            this.Load += new System.EventHandler(this.Academics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblCntrolsLayout;
    }
}
