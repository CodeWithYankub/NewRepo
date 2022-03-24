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

namespace SLMB_SMS.Views.Students
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
                pbImage.Image = Image.FromStream(Helper.PictureStream(Student.Image));
                lbGender.Text = Student.Gender.ToString();
                lbFullName.Text = string.Format("{0} {1} {2}", Student.LastName, Student.FirstName, Student.OtherName);
                lbEmail.Text = Student.Email;
                lbAddress.Text = Student.Address;
                lbDob.Text = Student.DateOfBirth.ToLongDateString();
                lbPhone.Text = Student.PhoneNo;

                lbParentAddress.Text = Student.ParentAddress;
                lbParentEmail.Text = Student.ParentEmail;
                lbParentName.Text = Student.ParentName;
                lbParentPhone.Text = Student.ParentPhone;
                lbOccupation.Text = Student.ParentOccuption;
                lbRelation.Text = Student.ParentRelationShip;

                lbActive.Text = Student.IsActive ? "No" : "Yes";
                lbID.Text = Student.ID.ToString();
                lbColor.Text = Student.Color.ToString();
                lbAdmitted.Text = Student.AddmisionDate.ToShortDateString();
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
