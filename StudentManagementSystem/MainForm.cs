using ControlsLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class MainForm : Form
    {
        Button previousClicked { get; set; }
        private bool loaded = false;
        public MainForm()
        {
            InitializeComponent();

            previousClicked = new Button();
        }

        #region Functions

        private DialogResult Splash()
        {
            Universal universal = new Universal();
            universal.FormBorderStyle = FormBorderStyle.None;
            universal.StartPosition = FormStartPosition.CenterScreen;
            universal.AddControl(string.Empty, new ControlsLibrary.Splash());
            return universal.ShowDialog();
        }
        
        private DialogResult Login()
        {
            Universal universal = new Universal();
            universal.StartPosition = FormStartPosition.CenterScreen;
            universal.AddControl("Login - School Management System", new ControlsLibrary.Login());
            return universal.ShowDialog();
        }

        private void SetUI()
        {
            Index index = new Index();
            index.Dock = DockStyle.Fill;
            Font = index.Font;

            if (Controls.Count > 0)
                Controls.Clear();

            Controls.Add(index);
        }

        public void DoLoad()
        {
            var logged = Login().Equals(DialogResult.OK);

            if (!logged)
                Environment.Exit(0);
            else
                SetUI();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool logout = Environment.GetEnvironmentVariable("Logout") == "1";

            if (logout)
            {
                DoLoad();
            }
            else
            {
                var splashed = Splash().Equals(DialogResult.OK);

                if (splashed)
                {
                    DoLoad();
                    loaded = splashed;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
