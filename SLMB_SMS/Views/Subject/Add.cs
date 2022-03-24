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

namespace SLMB_SMS.Views.Subject
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Sub Subject { get; set; }

        public Add(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Action = Helper.Action.Update;
                Subject = new Sub().Read(id);
            }
        }

        #region Custom Functions
        void Create(Sub subjects)
        {
            if (!subjects.Exists())
            {
                bool created = subjects.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Subject saved successfully", true);

                    // reset form
                    tbCode.ResetText();
                    tbName.ResetText();
                    tbName.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving subject");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Subject already exists");
                tbName.Focus();
            }
        }

        void Edit(Sub subject)
        {
            if (Subject.Name.Equals(subject.Name))
            {
                if (!subject.Exists(subject.Code))
                    PushEdits(subject);
                else
                    Helper.ShowMessage(lblStatus, "Subject already exist");
            }
            else
            {
                if (!subject.Exists(subject.Name))
                    PushEdits(subject);
                else
                    Helper.ShowMessage(lblStatus, "Subject already exist");
            }
        }

        void PushEdits(Sub subject)
        {
            bool updated = new Sub().Update(subject);

            if (updated)
                Helper.ShowMessage(lblStatus, "Subject updated successfully", true);
            else
                Helper.ShowMessage(lblStatus, "Error updating subject");
        }

        #endregion


        private void Add_Load(object sender, EventArgs e)
        {
            if (Action.Equals(Helper.Action.Update))
            {
                tbName.Text = Subject.Name;
                tbCode.Text = Subject.Code;
               

                tbName.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                Sub subject = new Sub()
                {
                    Name = tbName.Text,
                    Code = tbCode.Text
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    subject.ID = Subject.ID;
                    Edit(subject);
                }
                else
                {
                    Create(subject);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not supplied");
            }
        }
    }
}
