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

namespace ControlsLibrary.Faculties
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Faculty Faculty { get; set; }

        private Dictionary<string,int> Sectors { get; set; }
        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;
            Sectors = new Dictionary<string, int>();

            if (id > 0)
                Faculty = new Faculty().Read(id);
        }

        #region Functions
        void GetSectors()
        {
            List<Sector> sectors = new Sector().Read();

            if (cbSector.Items.Count > 0)
                cbSector.Items.Clear();

            cbSector.Items.Add("--- select ---");

            foreach(Sector sector in sectors)
            {
                string text = string.Format("{0} - {1}", sector.Name, sector.Acronym);
                cbSector.Items.Add(text);
                Sectors.Add(text, sector.ID);
            }

            cbSector.SelectedIndex = 0;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Faculty faculty = new Faculty()
                {
                    SectorId = Sectors[cbSector.Text],
                    Name = tbName.Text,
                    Acronym = tbAcronym.Text
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(faculty);
                }
                else
                {
                    Update(faculty);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void DoUpdates(Faculty faculty)
        {
            var updated = faculty.Update(Faculty.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lbError, "Facultry Updated Successfully", true);
            }
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Faculty faculty)
        {
            if (faculty.Name.Equals(Faculty.Name))
            {
                DoUpdates(faculty);
            }
            else
            {
                if (!faculty.Exists())
                {
                    DoUpdates(faculty);
                }
                else
                    Helper.ShowMessage(lbError, "Faculty already exists");
            }
        }

        private void Create(Faculty faculty)
        {
            if (!faculty.Exists())
            {
                var created = faculty.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Faculty Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Faculty already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetSectors();

            if (Action.Equals(App.Action.Edit))
            {
                Sector sector = new Sector().Read(Faculty.SectorId);
                cbSector.Text = string.Format("{0} - {1}", sector.Name, sector.Acronym);
                tbName.Text = Faculty.Name;
                tbAcronym.Text = Faculty.Acronym;

                btnSave.Text = "Update Record";
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text))
                tbAcronym.Text = Helper.GetAcronym(tbName.Text);
            else
                tbAcronym.ResetText();
        }
    }
}
