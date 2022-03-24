using ControlsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLMB_SMS
{
    public partial class MainForm : Form
    {
        Button previousClicked { get; set; }
        public MainForm()
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
                ctrls.Add("dashboard", new Dashboard());
            }

            try
            {
                btn.BackColor = Color.WhiteSmoke;
                btn.ForeColor = Color.FromArgb(2, 2, 2);

                lblTitle.Text = btn.Text;

                if (btn.Tag == null)
                    AddControl(ctrls[btn.Text.ToLower()]);

                previousClicked = btn;
            }
            catch
            {
                MessageBox.Show("Command not executable, try again later. If the problem persits contact developer.", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActivateButton(previousClicked);
            }
        }
        private void btnControls_Click(Object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            Dictionary<string, Control> ctrls = new Dictionary<string, Control>();
            /* Populate Controls */
            {
                ctrls.Add("dashboard", new Control());
                ctrls.Add("students", new Views.Students.Index());
                ctrls.Add("registration", new Views.Registrations.Index());
                ctrls.Add("teachers", new Views.Teachers.index());
                ctrls.Add("sectors", new ControlsLibrary.Sectors.Index());
                ctrls.Add("academic years", new Views.Years.Index());
                ctrls.Add("fees", new Views.Fees.index());
                ctrls.Add("faculties", new Views.Faculties.Index());
                ctrls.Add("subjects", new Views.Subject.index());
                ctrls.Add("forms", new Views.Forms.Index());
                ctrls.Add("levels", new Views.Level.Index());
                ctrls.Add("classes", new Views.classes.Index());
                ctrls.Add("grades", new Views.Grades.Index());
            }

            foreach (Button btn in tblControls.Controls)
            {
                btn.BackColor = Color.FromArgb(10, 50, 120);
                btn.ForeColor = Color.FromArgb(238, 238, 238);
            }

            lblTitle.Text = clicked.Text;
            clicked.BackColor = Color.WhiteSmoke;
            clicked.ForeColor = Color.FromArgb(2, 2, 2);
            try
            {
                AddControl(ctrls[clicked.Text.ToLower()]);
            }
            catch {
                MessageBox.Show("Command not executable, try again later. If the problem persits contact developer.", "Command Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddControl(Control ctrl)
        {
            if (Controls.Count > 0)
                Controls.Clear();

            ctrl.Dock = DockStyle.Fill;

            Font = ctrl.Font;
            Controls.Add(ctrl);
        }

        DialogResult Splash()
        {
            Universal universal = new Universal();
            universal.FormBorderStyle = FormBorderStyle.None;
            universal.StartPosition = FormStartPosition.CenterScreen;
            universal.AddControl(string.Empty, new Splash());
            return universal.ShowDialog();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            var splashed = Splash().Equals(DialogResult.OK);
            if (splashed)
            {
                // Login
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
