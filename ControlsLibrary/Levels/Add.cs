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

namespace ControlsLibrary.Levels
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Level Level { get; set; }

        private Dictionary<string,int> Sectors { get; set; }
        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;
            Sectors = new Dictionary<string, int>();

            if (id > 0)
                Level = new Level().Read(id);
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
                Level level = new Level()
                {
                    SectorId = Sectors[cbSector.Text],
                    Class = Convert.ToInt32(tbClass.Text)
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(level);
                }
                else
                {
                    Update(level);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void doUpdates(Level level)
        {
            var updated = level.Update(Level.ID);

            if (updated)
                ParentForm.DialogResult = DialogResult.OK;
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Level level)
        {
            if (!level.Exists())
            {
                var updated = level.Update(Level.ID);

                if (updated)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Level Updated Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
                Helper.ShowMessage(lbError, "Level already exists");
        }

        private void Create(Level level)
        {
            if (!level.Exists())
            {
                var created = level.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Level Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Level already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetSectors();

            if (Action.Equals(App.Action.Edit))
            {
                Sector sector = new Sector().Read(Level.SectorId);
                cbSector.Text = string.Format("{0} - {1}", sector.Name, sector.Acronym);
                tbClass.Text = Level.Class.ToString();

                btnSave.Text = "Update Record";
            }
        }

        private void tbClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
