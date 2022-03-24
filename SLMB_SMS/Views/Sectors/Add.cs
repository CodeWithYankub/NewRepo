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

namespace SLMB_SMS.Views.Sectors
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Sector Sector { get; set; }
        public Add(int sectorID = 0)
        {
            InitializeComponent();

            if (sectorID > 0)
            {
                Action = Helper.Action.Update;
                Sector = new Sector().Read(sectorID);
            }
            else
            {
                Action = Helper.Action.Create;
            }
        }

        #region Custom Functions
        void Create(Sector sector)
        {
            if (!sector.Exists())
            {
                bool created = sector.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Sector saved successfully", true);

                    // reset form
                    tbAcronym.ResetText();
                    tbName.ResetText();
                    tbName.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving record");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Sector name already exists");
                tbName.Focus();
            }
        }

        void Edit(Sector sector)
        {
            if (Sector.Name.Equals(sector.Name))
            {
                PushEdits(sector);
            }
            else
            {
                if (!sector.Exists())
                {
                    PushEdits(sector);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Sector name already exist");
                }
            }
        }

        void PushEdits(Sector sector)
        {
            bool updated = new Sector().Update(sector);

            if (updated)
            {
                Helper.ShowMessage(lblStatus,"Sector updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating sector");
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                Sector sectors = new Sector()
                {
                    Name = tbName.Text,
                    Acronym = tbAcronym.Text
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    sectors.ID = Sector.ID;
                    Edit(sectors);
                }
                else
                {
                    Create(sectors);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not supplied");
            }
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (Action.Equals(Helper.Action.Update))
            {
                tbName.Text = Sector.Name;
                tbAcronym.Text = Sector.Acronym;

                tbName.Focus();
            }
        }
    }
}
