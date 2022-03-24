using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary.Users
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private Dictionary<int, int> Virtual { get; set; }

        public Index()
        {
            InitializeComponent();

            Virtual = new Dictionary<int, int>();
        }

        #region Custom Functions
        List<User> FilterTeachers(List<User> users, string key)
        {
            var filtered = users.FindAll(user => user.ID.ToString().Contains(key));

            return filtered;
        }
        void FetchData(string key = null)
        {
            List<User> users = new User().Read();

            if (!string.IsNullOrEmpty(key))
            {
                users = FilterTeachers(users, key);
            }

            ShowData(users);

            Selected = 0;
        }


        void ShowData(List<User> users)
        {
            int index = 1;

            if (lstData.Items.Count > 0)
            {
                lstData.Items.Clear();
                Virtual.Clear();
            }

            foreach (User user in users)
            {
                if (!App.Logged.ID.Equals(user.ID))
                {
                    string[] arr = new string[]
                {
                    index.ToString(),
                    user.Name,
                    user.Gender.ToString(),
                    user.Phone,
                    user.Email,
                    user.Address,
                    user.UserType.ToString(),
                    user.Username,
                    user.Active ? "Active" : "Inactive",
                    user.DateRegistered.ToShortDateString()
                };

                    ListViewItem li = new ListViewItem(arr);
                    lstData.Items.Add(li);
                    Virtual.Add(index, user.ID);

                    index += 1;
                }
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Common common = new Common();
            if (sender is Button)
                common.AddControl("Add Teacher", new Adds());
            else
                common.AddControl("Edit teacher", new Adds(Selected));

            var completed = common.ShowDialog().Equals(DialogResult.OK);

            if (completed)
                FetchData();
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
            Helper.Resize(lstData);

            FetchData();
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            var isSelected = Selected > 0;
            btnContxEdit.Enabled = isSelected;
            btnContxView.Enabled = isSelected;
            btnContxEnableDisable.Enabled = isSelected;

            if (isSelected)
            {
                User user = new User().Read(Selected);
                btnContxEnableDisable.Text = user.Active ? "Deactivate" : "Activate";
                btnContxEnableDisable.Checked = user.Active;
            }
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                Selected = Virtual[Convert.ToInt32(e.Item.Text)];
            else
                Selected = 0;
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (Selected > 0)
                btnContxEdit.PerformClick();
        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void btnContxEnableDisable_Click(object sender, EventArgs e)
        {
            User user = new User().Read(Selected);
            user.Active = !user.Active;

            var updated = user.Update(user.ID);

            if (updated)
            {
                FetchData();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            bool printed = Printer.Print(lstData, "Students");

            if (printed)
            {
                MessageBox.Show("Document Exported Successfully", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
