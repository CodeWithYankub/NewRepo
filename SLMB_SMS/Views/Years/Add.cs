using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLMB_SMS.Models;

namespace SLMB_SMS.Views.Years
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Year Year { get; set; }
        public Add(int yearID = 0)
        {
            InitializeComponent();

            if (yearID > 0)
            {
                Action = Helper.Action.Update;
                Year = new Year().Read(yearID);
            }
            else
            {
                Action = Helper.Action.Create;
            }
        }

        #region Custom Functions
        bool FieldsCompleted()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType().Equals(new TextBox().GetType()))
                {
                    if (string.IsNullOrEmpty(ctrl.Text))
                        return false;
                }
            }
            return true;
        }

        void Create(Year year)
        {
            if (!year.Exists())
            {
                bool created = year.Create();

                if (created)
                {
                    ShowMessage(true, "Record saved");

                    // reset form
                    tbStart.ResetText();
                    tbEnd.ResetText();
                    cbIsPayable.SelectedIndex = 0;
                    tbStart.Focus();
                }
                else
                {
                    ShowMessage(false, "Error saving record");
                }
            }
            else
            {
                ShowMessage(false, "Year period already exists");
                tbStart.Focus();
            }
        }

        void Edit(Year year)
        {
            if (Year.Period.Equals(year.Period))
            {
                PushEdits(year);
            }
            else
            {
                if (!year.Exists())
                {
                    PushEdits(year);
                }
                else
                {
                    ShowMessage(false, "Year period already exist");
                }
            }
        }

        void PushEdits(Year year)
        {
            bool updated = new Year().Update(year);

            if (updated)
            {
                ShowMessage(true, "Year updated successfully");
            }
            else
            {
                ShowMessage(false, "Error updating year");
            }
        }

        void ShowMessage(bool success, string message)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = success ? Color.Green : Color.Red;
            Timer timer = new Timer() { Interval = 5000 };
            timer.Start();
            timer.Tick += (object sender, EventArgs e) =>
            {
                lblStatus.ResetText();
                timer.Dispose();
            };
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool filled = FieldsCompleted();

            if (filled)
            {
                Year year = new Year()
                {
                    Period = string.Format("{0}/{1}", tbStart.Text, tbEnd.Text),
                    IsPayble = cbIsPayable.SelectedIndex > 0
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    year.ID = Year.ID;
                    Edit(year);
                }
                else
                {
                    Create(year);
                }
            }
            else
            {
                ShowMessage(false, "Required fields not supplied");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            if (Action.Equals(Helper.Action.Update))
            {
                string[] period = Year.Period.Split('/');
                tbStart.Text = period[0];
                tbEnd.Text = period[1];
                cbIsPayable.SelectedIndex = Year.IsPayble ? 1 : 0;

                tbStart.Focus();
            }
            else
            {
                cbIsPayable.SelectedIndex = 0;
            }
        }

        private void tbStart_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbStart.Text))
            {
                tbEnd.Text = (int.Parse(tbStart.Text) + 1).ToString();
            }
        }

        private void tbStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }
    }
}
