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

namespace SLMB_SMS.Views.Faculties
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Faculty Faculty { get; set; }
        public Add(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Action = Helper.Action.Update;
                Faculty = new Faculty().Read(id);
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
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        void Create(Faculty faculty)
        {
            if (!faculty.Exists())
            {
                bool created = faculty.Create();

                if (created)
                {
                    ShowMessage(true, "Record saved");

                    // reset form
                    tbAcronym.ResetText();
                    tbName.ResetText();
                    tbName.Focus();
                }
                else
                {
                    ShowMessage(false, "Error saving record");
                }
            }
            else
            {
                ShowMessage(false, "Sector name already exists");
                tbName.Focus();
            }
        }

        void Edit(Faculty faculty)
        {
            if (Faculty.Name.Equals(faculty.Name))
            {
                PushEdits(faculty);
            }
            else
            {
                if (!faculty.Exists())
                {
                    PushEdits(faculty);
                }
                else
                {
                    ShowMessage(false, "Sector name already exist");
                }
            }
        }

        void PushEdits(Faculty faculty)
        {
            bool updated = new Faculty().Update(faculty);

            if (updated)
            {
                ShowMessage(true, "Sector updated successfully");
            }
            else
            {
                ShowMessage(false, "Error updating sector");
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
                Faculty faculty = new Faculty()
                {
                    Name = tbName.Text,
                    Acronym = tbAcronym.Text
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    faculty.ID = Faculty.ID;
                    Edit(faculty);
                }
                else
                {
                    Create(faculty);
                }
            }
            else
            {
                ShowMessage(false, "Required fields not supplied");
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
                tbName.Text = Faculty.Name;
                tbAcronym.Text = Faculty.Acronym;

                tbName.Focus();
            }
        }
    }
}
