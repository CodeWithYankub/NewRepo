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

namespace ControlsLibrary
{
    public partial class Index : UserControl
    {
        private Button previousClicked { get; set; }
        public Index()
        {
            InitializeComponent();

            previousClicked = new Button();
        }

        #region Custom Functions
        private void ActivateButton(Button btn)
        {
            Dictionary<string, Control> ctrls = new Dictionary<string, Control>();
            /* Populate Controls */
            {
                ctrls.Add("dashboard", new ControlsLibrary.Dashboard());
                ctrls.Add("teachers", new ControlsLibrary.Teachers.Index());
                ctrls.Add("academics", new ControlsLibrary.Academics());
                ctrls.Add("students", new ControlsLibrary.Students.Index());
                ctrls.Add("fees", new ControlsLibrary.Fees.Index());
                ctrls.Add("registration", new ControlsLibrary.Registrations.Index());
                ctrls.Add("grades", new ControlsLibrary.Grades.Index());
                ctrls.Add("users", new ControlsLibrary.Users.Index());
            }

            try
            {
                lblTitle.Text = btn.Text;

                btn.BackColor = Color.WhiteSmoke;
                btn.ForeColor = Color.FromArgb(2, 2, 2);
                string name = btn.Tag != null ? btn.Text.ToLower() : btn.Text.Split(' ')[1].ToString().ToLower();

                AddControl(ctrls[name]);

                previousClicked = btn;
            }
            catch
            {
                MessageBox.Show("Command not executable, try again later. If the problem persits contact developer.", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DeactivateButtons();
                ActivateButton(previousClicked);
            }
        }

        private void AddControl(Control ctrl)
        {
            if (panFill.Controls.Count > 0)
                panFill.Controls.Clear();

            ctrl.Dock = DockStyle.Fill;

            panFill.Font = ctrl.Font;
            panFill.Controls.Add(ctrl);
        }

        private void DeactivateButtons()
        {
            foreach (Button btn in tblControls.Controls)
            {
                btn.BackColor = Color.FromArgb(10, 50, 120);
                btn.ForeColor = Color.FromArgb(238, 238, 238);
            }
        }

        private void btnControls_Click(Object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            DeactivateButtons();
            ActivateButton(clicked);
        }

        private void SetUser()
        {
            User logged = App.Logged;
            lbFullName.Text = logged.Name;
            lbPhone.Text = string.Format("Phone: {0}", logged.Phone);
            lbEmail.Text = string.Format("Email: {0}", logged.Email);
            pbUserPhoto.Image = Image.FromStream(Helper.PictureStream(logged.Photo));
            lbJoined.Text = string.Format("Since: {0}", logged.DateRegistered.ToLongDateString());

            if (logged.UserType.Equals(App.UserType.Admin))
            {
                
                btnGrade.Enabled = false;
                btnFee.Enabled = false;
            }
            if (logged.UserType.Equals(App.UserType.Bursar))
            {
               // btnDashboard.Enabled = false;
                btnUsers.Enabled = false;
                btnAcademics.Enabled = false;
                btnTeachers.Enabled = false;
                btnGrade.Enabled = false;
                btnStudents.Enabled = false;
                btnRegistration.Enabled = false;
            }
            if (logged.UserType.Equals(App.UserType.ExamOfficer))
            {
                btnDashboard.Enabled = false;
                btnUsers.Enabled = false;
                btnAcademics.Enabled = false;
                btnTeachers.Enabled = false;
                btnFee.Enabled = false;
               // btnGrade.Enabled = false;
                btnStudents.Enabled = false;
                btnRegistration.Enabled = false;
            }
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
            SetUser();

            btnDashboard.PerformClick();
        }

        private void lbChangePassword_Click(object sender, EventArgs e)
        {
            Common common = new Common();
            common.AddControl("Chnage Password", new Users.ChangePassword());

            if (common.ShowDialog().Equals(DialogResult.OK))
                MessageBox.Show("Password Changed", "Chnage Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            App.Logged = new User();
            Environment.SetEnvironmentVariable("Logout", "1");
            Application.Restart();
        }
    }
}
