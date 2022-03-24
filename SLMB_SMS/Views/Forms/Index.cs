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

namespace SLMB_SMS.Views.Forms
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<int, int> Forms { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Forms = new Dictionary<int, int>();
        }


        #region Custom Functions
        void FetchData()
        {
            List<Models.Form> forms = new Models.Form().Read();
            Forms.Clear();

            ShowData(forms);
            isSelected = false;
        }

        void ShowData(List<Models.Form> forms)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            for (int i = 0; i < forms.Count; i++)
            {
                int index = i + 1;
                var form = forms[i];
                Classes clas = new Classes().Read(form.Class);
                Sector sector = new Sector().Read(clas.Sector);
                Faculty faculty = new Faculty().Read(clas.Faculty);
                Models.Level level = new Models.Level().Read(clas.Level);

                ListViewItem li = new ListViewItem(new string[] {
                    index.ToString(),
                    string.Format("{0} {1}{2}",sector.Acronym, level.Class, faculty.Acronym.ToLower()),
                    form.Name
                });
                lstData.Items.Add(li);
                Forms.Add(index, form.ID);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Sector", new Add());
            else
                universal.AddControl("Edit Sector", new Add(Selected));

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
                Selected = Forms[Convert.ToInt32(e.Item.Text)];
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

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }
    }
}
