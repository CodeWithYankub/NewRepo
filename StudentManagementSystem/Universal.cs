﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class Universal : Form
    {
        public Universal()
        {
            InitializeComponent();
        }

        public void AddControl(string title, Control ctrl, int h = 30, int w = 10)
        {
            Width = ctrl.Width + w;
            Height = ctrl.Height + h;
            Text = title;
            Font = ctrl.Font;

            ctrl.Dock = DockStyle.Fill;
            Controls.Add(ctrl);
        }
    }
}
