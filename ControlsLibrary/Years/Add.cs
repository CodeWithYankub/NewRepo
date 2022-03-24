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

namespace ControlsLibrary.Years
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Year Year { get; set; }
        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;

            if (id > 0)
                Year = new Year().Read(id);
        }

        private void Fields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tbStart_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbStart.Text))
            {
                tbEnd.Text = (Convert.ToInt32(tbStart.Text) + 1).ToString();
                tbPeriod.Text = string.Format("{0}/{1}", tbStart.Text, tbEnd.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Year year = new Year()
                {
                    Start = int.Parse(tbStart.Text),
                    End = int.Parse(tbEnd.Text),
                    Period = tbPeriod.Text,
                    Opened = chkIsOpened.Checked,
                    Paid = !chkIsFree.Checked
                };

                if(Action.Equals(App.Action.Create))
                {
                    Create(year);
                }
                else
                {
                    Update(year);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        private void doUpdate(Year year)
        {
            var updated = year.Update(Year.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lbError, "Year update successfully", true);
            }
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Year year)
        {
            if (year.Start.Equals(Year.Start))
            {
                doUpdate(year);
            }
            else
            {
                if (!year.Exists())
                    doUpdate(year);
                else
                    Helper.ShowMessage(lbError, "Year already exists");
            }
        }

        private void Create(Year year)
        {
            if (!year.Exists())
            {
                var created = year.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Year Saved successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Year already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (Action.Equals(App.Action.Edit))
            {
                tbStart.Text = Year.Start.ToString();
                tbEnd.Text = Year.End.ToString();
                tbPeriod.Text = Year.Period;
                chkIsOpened.Checked = Year.Opened;
                chkIsFree.Checked = !Year.Paid;

                btnSave.Text = "Update Record";
            }
        }
    }
}
