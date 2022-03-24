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

namespace ControlsLibrary.Students
{
    public partial class View : UserControl
    {
        private Student Student { get; set; }
        public View(int id)
        {
            InitializeComponent();

            Student = new Student().Read(id);
        }

        void ShowData()
        {
            if (!Student.Equals(null))
            {
                pbImage.Image = Image.FromStream(Helper.PictureStream(Student.Photo));
                pbResult.Image = Image.FromStream(Helper.ResultStream(Student.Result));
                lbGender.Text = Student.Gender.ToString();
                lbFullName.Text = string.Format("{0} {1} {2}", Student.LastName, Student.FirstName, Student.OtherName);
                lbEmail.Text = Student.Email;
                lbAddress.Text = Student.Address;
                lbDob.Text = Student.DateOfBirth.ToLongDateString();
                lbPhone.Text = Student.Phone;

                lbParentAddress.Text = Student.ParentDetails.Address;
                lbParentEmail.Text = Student.ParentDetails.Email;
                lbParentName.Text = Student.ParentDetails.Name;
                lbParentPhone.Text = Student.ParentDetails.Phone;
                lbOccupation.Text = Student.ParentDetails.Occupation;
                lbRelation.Text = Student.ParentDetails.Relationship;

                lbActive.Text = Student.Active ? "No" : "Yes";
                lbID.Text = Student.ID.ToString();
                lbColor.Text = Student.Color.ToString();
                lbAdmitted.Text = Student.AdmittedOn.ToLongDateString();

                User user = new User().Read(Student.AdmittedBy);
                lbAdmitedBy.Text = user != null ? user.Username : "void";

                Year year = new Year().Read(Student.YearId);
                lbYear.Text = year.Period;
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printer.Print(this, 70, false);
        }
    }
}
