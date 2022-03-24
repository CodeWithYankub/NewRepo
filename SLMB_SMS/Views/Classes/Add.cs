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

namespace SLMB_SMS.Views.classes
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Classes Classes { get; set; }
        private Dictionary<string, int> Levels { get; set; }
        private Dictionary<string, int> Faculties { get; set; }
        public Add(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Action = Helper.Action.Update;
                Classes = new Classes().Read(id);
            }

            Levels = new Dictionary<string, int>();
            Faculties = new Dictionary<string, int>();
        }

        #region Custom Functions
        void fetchLevels()
        {
            List<Models.Level> levels = new Models.Level().Read();

            if (levels.Count > 0)
            {
                Levels.Clear();
                cbLevels.Items.Clear();
                cbLevels.Items.Add("--- select ---");
            }

            foreach (var level in levels)
            {
                var sector = new Sector().Read(level.Sector);
                cbLevels.Items.Add(string.Format("{0} {1} - {2}", sector.Acronym, level.Class, sector.Name));
                Levels.Add(string.Format("{0} {1} - {2}", sector.Acronym, level.Class, sector.Name), level.ID);
            }

            cbLevels.SelectedIndex = 0;
        }
        
        void fetchFaculties()
        {
            List<Faculty> faculties = new Faculty().Read();

            if (faculties.Count > 0)
            {
                Faculties.Clear();
                cbFaculties.Items.Clear();
                cbFaculties.Items.Add("--- select ---");
            }

            foreach (var faculty in faculties)
            {
                cbFaculties.Items.Add(string.Format("{0}", faculty.Name));
                Faculties.Add(string.Format("{0}", faculty.Name), faculty.ID);
            }

            cbFaculties.SelectedIndex = 0;
        }

        void Create(Classes clas)
        {
            clas.Sector = new Models.Level().Read(clas.Level).Sector;

            if (!clas.Exists())
            {
                bool created = clas.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Class saved successfully", true);

                    // reset form
                    cbLevels.SelectedIndex = 0;
                    cbFaculties.SelectedIndex = 0;
                    cbLevels.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving class");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Class already exists");
                cbLevels.Focus();
            }
        }

        void Edit(Classes clas)
        {
            if (Classes.Level.Equals(clas.Level) && Classes.Faculty.Equals(clas.Faculty))
            {
                PushEdits(clas);
            }
            else
            {
                if (!clas.Exists())
                {
                    PushEdits(clas);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Class already exist");
                }
            }
        }
        void PushEdits(Classes clas)
        {
            clas.Sector = new Models.Level().Read(clas.Level).Sector;
            bool updated = new Classes().Update(clas);

            if (updated)
            {
                Helper.ShowMessage(lblStatus, "Class updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating class");
            }
        }
        #endregion

        private void Add_Load(object sender, EventArgs e)
        {
            fetchLevels();
            fetchFaculties();

            if (Action.Equals(Helper.Action.Update))
            {
                Faculty faculty = new Faculty().Read(Classes.Faculty);
                cbFaculties.Text = faculty.Name;

                Models.Level level = new Models.Level().Read(Classes.Level);
                Sector sector = new Sector().Read(level.Sector);
                cbLevels.Text = string.Format("{0} {1} - {2}", sector.Acronym, level.Class, sector.Name);

                cbLevels.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                Classes clas = new Classes()
                {
                    Level = Levels[cbLevels.Text],
                    Faculty = Faculties[cbFaculties.Text]
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    clas.ID = Classes.ID;
                    Edit(clas);
                }
                else
                {
                    Create(clas);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not completed");
            }
        }
    }
}
