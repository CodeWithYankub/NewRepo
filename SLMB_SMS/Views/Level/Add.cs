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

namespace SLMB_SMS.Views.Level
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Models.Level Level { get; set; }
        private Dictionary<string, int> Levels { get; set; }
        public Add(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Action = Helper.Action.Update;
                Level = new Models.Level().Read(id);
            }

            Levels = new Dictionary<string, int>();
        }

        #region Custom Functions
        void fetchSectors()
        {
            List<Sector> sectors = new Sector().Read();

            if (sectors.Count > 0)
            {
                Levels.Clear();
                cbSectors.Items.Clear();
                cbSectors.Items.Add("--- select ---");
            }

            foreach(var sector in sectors)
            {
                cbSectors.Items.Add(string.Format("{0} ({1})", sector.Name, sector.Acronym));
                Levels.Add(string.Format("{0} ({1})", sector.Name, sector.Acronym), sector.ID);
            }

            cbSectors.SelectedIndex = 0;
        }

        void Create(Models.Level level)
        {
            if (!level.Exists())
            {
                bool created = level.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Level saved successfully", true);

                    // reset form
                    cbSectors.SelectedIndex = 0;
                    tbClass.ResetText();
                    cbSectors.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving level");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Level already exists");
                cbSectors.Focus();
            }
        }

        void Edit(Models.Level level)
        {
            if (Level.Class.Equals(level.Class) && Level.Sector.Equals(level.Sector))
            {
                PushEdits(level);
            }
            else
            {
                if (!level.Exists())
                {
                    PushEdits(level);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Level already exist");
                }
            }
        }
        void PushEdits(Models.Level level)
        {
            bool updated = new Models.Level().Update(level);

            if (updated)
            {
                Helper.ShowMessage(lblStatus, "Level updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating level");
            }
        }
        #endregion

        private void Add_Load(object sender, EventArgs e)
        {
            fetchSectors();

            if (Action.Equals(Helper.Action.Update))
            {
                Sector sector = new Sector().Read(Level.Sector);
                tbClass.Text = Level.Class.ToString();
                cbSectors.Text = string.Format("{0} ({1})", sector.Name, sector.Acronym);

                cbSectors.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                Models.Level level = new Models.Level()
                {
                    Class = int.Parse(tbClass.Text),
                    Sector = Levels[cbSectors.Text]
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    level.ID = Level.ID;
                    Edit(level);
                }
                else
                {
                    Create(level);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not completed");
            }
        }

        private void tbClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }
    }
}
