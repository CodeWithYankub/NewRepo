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

namespace ControlsLibrary.Subjects
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Subject Subject { get; set; }

        private Dictionary<string,int> Sectors { get; set; }
        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;
            Sectors = new Dictionary<string, int>();

            if (id > 0)
                Subject = new Subject().Read(id);
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
                Subject subject = new Subject()
                {
                    SectorId = Sectors[cbSector.Text],
                    Name = tbName.Text,
                    Code = Convert.ToInt32(tbCode.Text)
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(subject);
                }
                else
                {
                    Update(subject);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void doUpdates(Subject subject)
        {
            var updated = subject.Update(Subject.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lbError, "Subject Updated Successfully", true);
            }
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Subject subject)
        {
            if (subject.Code.Equals(Subject.Code))
            {
                doUpdates(subject);
            }
            else
            {
                if (!subject.Exists())
                    doUpdates(subject);
                else
                    Helper.ShowMessage(lbError, "Subject already exists");
            }

        }

        private void Create(Subject subject)
        {
            if (!subject.Exists())
            {
                var created = subject.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Subject Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Subject already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetSectors();

            if (Action.Equals(App.Action.Edit))
            {
                Sector sector = new Sector().Read(Subject.SectorId);
                cbSector.Text = string.Format("{0} - {1}", sector.Name, sector.Acronym);
                tbName.Text = Subject.Name;
                tbCode.Text = Subject.Code.ToString();

                btnSave.Text = "Update Record";
            }
        }

        private void tbCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
