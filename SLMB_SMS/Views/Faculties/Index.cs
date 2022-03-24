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

namespace SLMB_SMS.Views.Faculties
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<string, int> Faculties { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Faculties = new Dictionary<string, int>();
        }

        #region Custom Functions
        void FetchData()
        {
            List<Faculty> faculties = new Faculty().Read();
            Faculties.Clear();

            ShowData(faculties);
            isSelected = false;
        }

        void ShowData(List<Faculty> faculties)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            foreach (Faculty faculty in faculties)
            {
                ListViewItem li = new ListViewItem(new string[] { faculty.Name, faculty.Acronym });
                Faculties.Add(faculty.Name, faculty.ID);
                lstData.Items.Add(li);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Faculty", new Add());
            else
                universal.AddControl("Edit Faculty", new Add(Selected));

            universal.ShowDialog();

            FetchData();
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
            FetchData();
        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            isSelected = e.IsSelected;

            if (isSelected)
                Selected = Faculties[e.Item.Text];
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }
    }
}
