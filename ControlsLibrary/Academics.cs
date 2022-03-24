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
    public partial class Academics : UserControl
    {
        public Academics()
        {
            InitializeComponent();
        }

        #region Functions
        void SetControls()
        {
            int i = 0;
            List<Control> controls = new List<Control>();

            if (tblCntrolsLayout.Controls.Count > 0)
                tblCntrolsLayout.Controls.Clear();

            /* Populate controls for classrooms tab */
            {
                controls.Add(new Streams.Index());
                controls.Add(new Classes.Index());
                controls.Add(new Levels.Index());
                //controls.Add(new FacultySubjects.Index());
                controls.Add(new Faculties.Index());
                controls.Add(new Subjects.Index());
                controls.Add(new Sectors.Index());
                controls.Add(new Years.Index());
            }

            foreach(Control ctrl in controls)
            {
                ctrl.Dock = DockStyle.Fill;
                ctrl.Margin = new Padding(5);
                ctrl.Font = tblCntrolsLayout.Font;
                tblCntrolsLayout.Controls.Add(ctrl);

                if (i < 1)
                    tblCntrolsLayout.SetColumnSpan(ctrl, 2);

                i += 1;
            }
        }
        
        #endregion 

        private void Academics_Load(object sender, EventArgs e)
        {
            SetControls();
        }
    }
}
