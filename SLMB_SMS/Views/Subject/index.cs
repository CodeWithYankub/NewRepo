using SLMB_SMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLMB_SMS.Views.Subject
{
    public partial class index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<string, int> Subs{ get; set; }
        public index()
        {
            InitializeComponent();
            isSelected = false;
            Subs = new Dictionary<string, int>();
        }
        #region Custom Functions
        void FetchData(string index = null)
        {
            List<Sub> subs = new Sub().Read();

            if (!string.IsNullOrEmpty(index))
            {
                subs = new Sub().Search(index);
            }

            Subs.Clear();

            ShowData(subs);
            isSelected = false;
        }

        void ShowData(List<Sub> subs)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            foreach (Sub sub in subs)
            {
                ListViewItem li = new ListViewItem(new string[] { sub.Name, sub.Code });
                Subs.Add(sub.Name, sub.ID);
                lstData.Items.Add(li);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Subject", new Add());
            else
                universal.AddControl("Edit Subject", new Add(Selected));

            universal.ShowDialog();

            FetchData();
        }
        #endregion

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Subject", new Add());
            else
                universal.AddControl("Edit Subect", new Add(Selected));

            universal.ShowDialog();

            FetchData();
        }
        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
            btnContxDelete.Enabled = isSelected;
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void index_Load(object sender, EventArgs e)
        {
            FetchData();
        }

        private void index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            isSelected = e.IsSelected;

            if (isSelected)
                Selected = Subs[e.Item.Text];
            else
                Selected = 0;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                FetchData(tbSearch.Text);
            }
            else
            {
                FetchData();
            }
        }

        private void btnContxDelete_Click(object sender, EventArgs e)
        {
            var confirmed = MessageBox.Show("Are you sure to delete this subject?", "Delete Subject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmed.Equals(DialogResult.Yes))
            {
                var deleted = new Sub().Delete(Selected);

                if (deleted)
                {
                    MessageBox.Show("Subject deleted successfully", "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FetchData();
                }
                else
                {
                    MessageBox.Show("Error deleting subject", "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog brw = new OpenFileDialog()
            {
                Filter = "Comma Delimeted|*.csv",
                Title = "Select File"
            };

            if (brw.ShowDialog().Equals(DialogResult.OK))
            {
                int added = 0;
                string[] lines = System.IO.File.ReadAllLines(brw.FileName);
                Dictionary<int, string> subjects = new Dictionary<int, string>();

                foreach(string line in lines)
                {
                    if (!line.StartsWith("c"))
                    {
                        string[] line_arr = line.Split(',');
                        string code = line_arr[0];
                        string name = line_arr[1];

                        if (!subjects.ContainsKey(int.Parse(code)))
                        {
                            subjects.Add(int.Parse(code), name);
                        }
                    }
                }
                
                foreach(var subject in subjects)
                {
                    Sub sub = new Sub()
                    {
                        Code = subject.Key.ToString(),
                        Name = subject.Value
                    };

                    if (!sub.Exists())
                    {
                        bool created = sub.Create();

                        if (created)
                            added += 1;
                    }
                }

                MessageBox.Show(string.Format("{0} subjects added", added));
                btnContxRefresh.PerformClick();
            }
        }
    }
}
