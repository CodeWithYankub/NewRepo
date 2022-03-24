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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  bool userCLose = e.CloseReason.Equals(CloseReason.UserClosing) || e.CloseReason.Equals(CloseReason.TaskManagerClosing);

           // if (userCLose)
             //   Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
