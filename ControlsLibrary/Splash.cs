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
    public partial class Splash : UserControl
    {
        int trials = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer() { Interval = 1000 };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            if (trials > 1)
            {
                bool connected = ClassLibrary.DBHelper.IsConnected;
                if (connected)
                {
                    timer.Stop();
                    timer.Dispose();
                    Form frm = ParentForm;
                    frm.DialogResult = DialogResult.OK;
                    frm.Close();
                }
                else
                {
                    if (trials > 4)
                    {
                        timer.Stop();

                        MessageBox.Show(ClassLibrary.App.Error, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        timer.Dispose();
                        Application.Exit();
                    }
                }
            }

            trials += 1;
        }
    }
}
