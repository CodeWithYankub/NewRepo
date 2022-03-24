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

namespace SLMB_SMS.Views.Registrations
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Registration Registration { get; set; }
        private Dictionary<string, int> Forms { get; set; }
        private Dictionary<string, int> Years { get; set; }
        public Add(int id = 0)
        {
            InitializeComponent();
            if (id > 0)
            {
                Action = Helper.Action.Update;
                Registration = new Registration().Read(id);
            }

            Years = new Dictionary<string, int>();
            Forms = new Dictionary<string, int>();
        }
        #region Custom Functions
        void fetchYears()
        {
            List<Year> years = new Year().Read();

            if (years.Count > 0)
            {
                Years.Clear();
                cbYear.Items.Clear();
                cbYear.Items.Add("--- select ---");
            }

            foreach (Year year in years)
            {
                if (year.Status.Equals(Helper.Status.Enabled))
                {
                    cbYear.Items.Add(year.Period);
                    Years.Add(year.Period, year.ID);
                }
            }

            cbYear.SelectedIndex = 0;
        }
        
        void fetchForms()
        {
            List<Models.Form> forms = new Models.Form().Read();

            if (forms.Count > 0)
            {
                Forms.Clear();
                cbForm.Items.Clear();
                cbForm.Items.Add("--- select ---");
            }

            foreach (Models.Form form in forms)
            {
                Classes clas = new Classes().Read(form.Class);
                Sector sector = new Sector().Read(clas.Sector);
                Faculty faculty = new Faculty().Read(clas.Faculty);
                Models.Level level = new Models.Level().Read(clas.Level);

                cbForm.Items.Add(string.Format("{0} {1}{2} ({3})", sector.Acronym, level.Class, faculty.Acronym, form.Name));
                Forms.Add(string.Format("{0} {1}{2} ({3})", sector.Acronym, level.Class, faculty.Acronym, form.Name), form.ID);
            }

            cbForm.SelectedIndex = 0;
        }

        void Create(Registration registration)
        {
            if (!registration.Exists())
            {
                bool created = registration.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Regitration saved successfully", true);

                    // reset form
                    cbYear.SelectedIndex = 0;
                    tbReceipt.ResetText();
                    tbStudentID.ResetText();
                    cbForm.SelectedIndex = 0;
                    tbReceipt.ResetText();
                    tbReceipt.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving Student");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Registration already exists");
                tbReceipt.Focus();
            }
        }

        void Edit(Registration registration)
        {
            bool updated = new Registration().Update(registration);

            if (updated)
            {
                Helper.ShowMessage(lblStatus, "Registration updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating registration");
            }
        }
        #endregion


        private void Addmit_Load(object sender, EventArgs e)
        {
            fetchForms();
            fetchYears();

            if (Action.Equals(Helper.Action.Update))
            {
                Models.Form form = new Models.Form().Read(Registration.Form);
                Classes clas = new Classes().Read(form.Class);
                Sector sector = new Sector().Read(clas.Sector);
                Faculty faculty = new Faculty().Read(clas.Faculty);
                Models.Level level = new Models.Level().Read(clas.Level);

                string form_data = string.Format("{0} {1}{2} ({3})", sector.Acronym, level.Class, faculty.Acronym, form.Name);

                tbReceipt.Text = Registration.Receipt.ToString();
                tbStudentID.Text = Registration.Student.ToString();
                cbYear.Text = new Year().Read(Registration.Year).Period;
                cbForm.Text = form_data;
                dpDateregistred.Value = Registration.DateRegisterd;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                Fee fee = new Fee().Read(int.Parse(tbReceipt.Text));

                if (fee != null)
                {
                    if (fee.Student.Equals(int.Parse(tbStudentID.Text)))
                    {
                        Registration registration = new Registration()
                        {
                            ID = int.Parse(tbReceipt.Text),
                            Student = int.Parse(tbStudentID.Text),
                            Year = Years[cbYear.Text],
                            Form = Forms[cbForm.Text],
                            Receipt = int.Parse(tbReceipt.Text),
                            DateRegisterd = dpDateregistred.Value
                        };

                        if (Action.Equals(Helper.Action.Update))
                        {
                            registration.ID = Registration.ID;
                            Edit(registration);
                        }
                        else
                        {
                            Create(registration);
                        }
                    }
                    else
                    {
                        Helper.ShowMessage(lblStatus, "Student does not match payment record");
                        tbStudentID.Focus();
                    }
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Invalid receipt number");
                    tbReceipt.Focus();
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not completed");
            }
        }
    }
}
