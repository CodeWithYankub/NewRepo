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

namespace SLMB_SMS.Views.Forms
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Models.Form Form  { get; set; }
        private Dictionary<string, int> Classes { get; set; }
        public Add(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Action = Helper.Action.Update;
                Form = new Models.Form().Read(id);
            }

            Classes = new Dictionary<string, int>();
        }

        #region Custom Functions
        void fetchClasses()
        {
            List<Classes> classes = new Classes().Read();

            if (classes.Count > 0)
            {
                Classes.Clear();
                cbClasses.Items.Clear();
                cbClasses.Items.Add("--- select ---");
            }

            foreach (var clas in classes)
            {
                Sector sector = new Sector().Read(clas.Sector);
                Faculty faculty = new Faculty().Read(clas.Faculty);
                Models.Level level = new Models.Level().Read(clas.Level);
                cbClasses.Items.Add(string.Format("{0} {1}{2}", sector.Acronym, level.Class, faculty.Acronym.ToLower()));
                Classes.Add(string.Format("{0} {1}{2}", sector.Acronym, level.Class, faculty.Acronym.ToLower()), clas.ID);
            }

            cbClasses.SelectedIndex = 0;
        }

        void Create(Models.Form form)
        {
            if (!form.Exists())
            {
                bool created = form.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Form saved successfully", true);

                    // reset form
                    cbClasses.SelectedIndex = 0;
                    tbName.ResetText();
                    cbClasses.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving form");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Form already exists");
                cbClasses.Focus();
            }
        }

        void Edit(Models.Form form)
        {
            if (Form.Name.Equals(form.Name))
            {
                if (!form.Exists(form.Class.ToString()))
                    PushEdits(form);
                else
                    Helper.ShowMessage(lblStatus, "Form already exist");
            }
            else
            {
                if (!form.Exists(form.Name))
                    PushEdits(form);
                else
                    Helper.ShowMessage(lblStatus, "Form already exist");
            }
        }
        void PushEdits(Models.Form form)
        {
            bool updated = new Models.Form().Update(form);

            if (updated)
            {
                Helper.ShowMessage(lblStatus, "Form updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating form");
            }
        }
        #endregion

        private void Add_Load(object sender, EventArgs e)
        {
            fetchClasses();

            if (Action.Equals(Helper.Action.Update))
            {
                Classes clas = new Classes().Read(Form.Class);
                Sector sector = new Sector().Read(clas.Sector);
                Faculty faculty = new Faculty().Read(clas.Faculty);
                Models.Level level = new Models.Level().Read(clas.Level);
                tbName.Text = Form.Name;
                cbClasses.Text = string.Format("{0} {1}{2}", sector.Acronym, level.Class, faculty.Acronym.ToLower());

                cbClasses.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                Models.Form form = new Models.Form()
                {
                    Class = Classes[cbClasses.Text],
                    Name=tbName.Text
                };

                if (Action.Equals(Helper.Action.Update))
                {
                    form.ID = Form.ID;
                    Edit(form);
                }
                else
                {
                    Create(form);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not completed");
            }
        }
    }
}
