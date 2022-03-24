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
    public partial class Universal : Form
    {
        public Universal()
        {
            InitializeComponent();
        }

        public void AddControl(string title, Control ctrl)
        {
            Width = ctrl.Width + 10;
            Height = ctrl.Height + 30;
            Text = title;

            ctrl.Dock = DockStyle.Fill;
            Controls.Add(ctrl);
        }
    }
}
