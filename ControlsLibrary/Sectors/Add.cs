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

namespace ControlsLibrary.Sectors
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Sector Sector { get; set; }
        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;

            if (id > 0)
                Sector = new Sector().Read(id);
        }

        private void Fields_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            tbAcronym.Text = Helper.GetAcronym(tbName.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Sector sector = new Sector()
                {
                    Name = tbName.Text,
                    Acronym = tbAcronym.Text
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(sector);
                }
                else
                {
                    Update(sector);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        private void Update(Sector sector)
        {
            if (!sector.Exists())
            {
                var updated = sector.Update(Sector.ID);

                if (updated)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Sector Updated Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Sector with same name exists already");
            }
        }

        private void Create(Sector sector)
        {
            if (!sector.Exists())
            {
                var created = sector.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Sector Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Sector already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (Action.Equals(App.Action.Edit))
            {
                tbName.Text = Sector.Name;
                tbAcronym.Text = Sector.Acronym;

                btnSave.Text = "Update Record";
            }
        }
    }
}
