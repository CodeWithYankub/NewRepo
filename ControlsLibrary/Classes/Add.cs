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

namespace ControlsLibrary.Classes
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Class Class { get; set; }

        private Dictionary<string,int> Sectors { get; set; }
        private Dictionary<string,int> Faculties { get; set; }
        private Dictionary<string,int> Levels { get; set; }
        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;
            Sectors = new Dictionary<string, int>();
            Faculties = new Dictionary<string, int>();
            Levels = new Dictionary<string, int>();

            if (id > 0)
                Class = new Class().Read(id);
        }

        #region Functions
        void GetSectors()
        {
            List<Sector> sectors = new Sector().Read();

            if (cbSector.Items.Count > 0)
                cbSector.Items.Clear();

            cbSector.Items.Add("--- select ---");
            Sectors.Clear();

            foreach(Sector sector in sectors)
            {
                string text = string.Format("{0} - {1}", sector.Name, sector.Acronym);
                cbSector.Items.Add(text);
                Sectors.Add(text, sector.ID);
            }

            cbSector.SelectedIndex = 0;
        }

        void GetFaculties(int sectorId)
        {
            List<Faculty> faculties = new Faculty().Read();

            if (cbFaculty.Items.Count > 0)
                cbFaculty.Items.Clear();

            cbFaculty.Items.Add("--- select ---");
            Faculties.Clear();

            foreach (Faculty faculty in faculties)
            {
                if (faculty.SectorId.Equals(sectorId))
                {
                    string text = string.Format("{0} - {1}", faculty.Name, faculty.Acronym);
                    cbFaculty.Items.Add(text);
                    Faculties.Add(text, faculty.ID);
                }
            }

            cbFaculty.SelectedIndex = 0;
        }

        void GetLevels(int sectorId)
        {
            List<Level> levels = new Level().Read();

            if (cbLevel.Items.Count > 0)
                cbLevel.Items.Clear();

            cbLevel.Items.Add("--- select ---");
            Levels.Clear();

            foreach (Level level in levels)
            {
                if (level.SectorId.Equals(sectorId))
                {
                    string text = Helper.ToRomans(level.Class);
                    cbLevel.Items.Add(text);
                    Levels.Add(text, level.ID);
                }
            }

            cbLevel.SelectedIndex = 0;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Class classe = new Class()
                {
                    SectorId = Sectors[cbSector.Text],
                    FacultyId = Faculties[cbFaculty.Text],
                    LevelId = Levels[cbLevel.Text]
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(classe);
                }
                else
                {
                    Update(classe);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void doUpdates(Class classe)
        {
            var updated = classe.Update(Class.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lbError, "Class Upadeted Successfully", true);
            }
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Class classe)
        {
            if (!classe.Exists())
                doUpdates(classe);
            else
                Helper.ShowMessage(lbError, "Class already exists");
        }

        private void Create(Class classe)
        {
            if (!classe.Exists())
            {
                var created = classe.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Class Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Class already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetSectors();

            if (Action.Equals(App.Action.Edit))
            {
                Sector sector = new Sector().Read(Class.SectorId);
                Faculty faculty = new Faculty().Read(Class.FacultyId);
                Level level = new Level().Read(Class.LevelId);
                cbSector.Text = string.Format("{0} - {1}", sector.Name, sector.Acronym);
                cbFaculty.Text = string.Format("{0} - {1}", faculty.Name, faculty.Acronym);
                cbLevel.Text = Helper.ToRomans(level.Class);

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

        private void cbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSector.SelectedIndex > 0)
            {
                GetFaculties(Sectors[cbSector.Text]);
                GetLevels(Sectors[cbSector.Text]);
            }
            else
            {
                cbFaculty.Items.Clear();
                cbFaculty.Items.Add("--- select ---");
                cbFaculty.SelectedIndex = 0;

                cbLevel.Items.Clear();
                cbLevel.Items.Add("--- select ---");
                cbLevel.SelectedIndex = 0;
            }
        }

        internal static void IsValidPhoneNumber()
        {
            throw new NotImplementedException();
        }
    }
}
