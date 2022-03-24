
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
    public partial class Admit : UserControl
    {
        private string imgPath { get; set; }
        private string Resultpath { get; set; }
        private Student Student { get; set; }
        private App.Action action { get; set; }
        private Dictionary<string, int> Years { get; set; }
        public Admit(int id = 0)
        {
            InitializeComponent();

            Years = new Dictionary<string, int>();

            if (id > 0)
            {
                Student = new Student().Read(id);
                action = App.Action.Edit;
            }
        }

        #region Functions
        private void Update(Student student)
        {
            if (student.ID.Equals(Student.ID))
            {
                DoUpdate(student);
            }
            else
            {
                if (!student.Exists())
                {
                    DoUpdate(student);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Student with this ID already exist");
                }
            }
        }

        private void DoUpdate(Student student)
        {
            bool updated = student.Update(Student.ID);

            if (updated)
            {
                Helper.Upload(student.Photo, imgPath);
                Helper.Upload(student.Result, Resultpath);
                Helper.ClearFields(this);
                Helper.ShowMessage(lblStatus, "Student updated successfully",true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, App.Error);
            }
        }

        private void Create(Student student)
        {
            if (!student.Exists())
            {
                bool created = student.Create();

                if (created)
                {
                    Helper.Upload(student.Photo, imgPath);
                    Helper.Upload(student.Result, Resultpath);
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lblStatus, "Student created successfully",true);
                }
                else
                    Helper.ShowMessage(lblStatus, App.Error);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Student already admitted");
            }
        }

        private void GetYears()
        {
            List<Year> years = new Year().Read();

            foreach(Year year in years)
            {
                if (year.Opened)
                {
                    cbYear.Items.Add(year.Period);
                    Years.Add(year.Period, year.ID);
                }
            }
        }

        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
             if (e.KeyChar >= '0' && e.KeyChar <='9' || e.KeyChar == '+' || char.IsControl(e.KeyChar))
          
            {
               e.Handled = false; //Do not reject the input
            }
          else
                {
                   e.Handled = true;
                }
            
        }
        #endregion
      
        private void Admit_Load(object sender, EventArgs e)
        {
            GetYears();

            dtpDOB.MaxDate = DateTime.Now.Date;
            dtpAdmitted.MaxDate = DateTime.Now.Date;

            if (action.Equals(App.Action.Create))
            {
                cbColor.SelectedIndex = 0;
                cbGender.SelectedIndex = 0;
                cbYear.SelectedIndex = 0;
            }
            else
            {
                Year year = new Year().Read(Student.YearId);
                imgPath = Student.Photo;
                Resultpath = Student.Result;
                tbAddress.Text = Student.Address;
                tbEmail.Text = Student.Email;
                tbSurname.Text = Student.LastName;
                tbGivenName.Text = Student.FirstName;
                tbOtherName.Text = Student.OtherName;
                tbID.Text = Student.ID.ToString();
                tbPhone.Text = Student.Phone;
                tbPName.Text = Student.ParentDetails.Name;
                tbPPhone.Text = Student.ParentDetails.Phone;
                tbPEmail.Text = Student.ParentDetails.Email;
                tbPAddress.Text = Student.ParentDetails.Address;
                tbOccupation.Text = Student.ParentDetails.Occupation;
                tbRelation.Text = Student.ParentDetails.Relationship;
                cbGender.Text = Student.Gender.ToString();
                cbColor.Text = Student.Color.ToString();
                dtpAdmitted.Value = Student.AdmittedOn;
                dtpDOB.Value = Student.DateOfBirth;
                cbYear.Text = year.Period;

                picImgPath.Image = Image.FromStream(Helper.PictureStream(Student.Photo));
                picResult.Image = Image.FromStream(Helper.ResultStream(Student.Result));

                chkCloneAdress.Checked = Student.Address.Equals(Student.ParentDetails.Address);

                btnSave.Text = "Update Record";
                imgPath = string.Format(@"{0}\{1}", Helper.UploadPath, Student.Photo);
                Resultpath = string.Format(@"{0}\{1}", Helper.UploadPath, Student.Result);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog brw = new OpenFileDialog()
            {
                Filter = "Supported (*.jpg)|*.jpg",
                Title = "Student Photo"
            };

            if (brw.ShowDialog().Equals(DialogResult.OK))
            {
                imgPath = brw.FileName;
                picImgPath.ImageLocation = imgPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = Helper.FieldsCompleted(this);

            if (valid)
            {
                bool isMinMatch = Helper.FieldValid(this);

                if (isMinMatch)
                {
                    Student.Parent parent = new Student.Parent()
                    {
                        Name = tbPName.Text,
                        Address = tbPAddress.Text,
                        Email = tbPEmail.Text,
                        Phone = tbPPhone.Text,
                        Occupation = tbOccupation.Text,
                        Relationship = tbRelation.Text
                    };

                    Student student = new Student()
                    {
                        FirstName = tbGivenName.Text,
                        LastName = tbSurname.Text,
                        OtherName = tbOtherName.Text,
                        Gender = (App.Gender)cbGender.SelectedIndex - 1,
                        AdmittedOn = dtpAdmitted.Value,
                        AdmittedBy = App.Logged.ID,
                        Address = tbAddress.Text,
                        Color = (App.Color)cbColor.SelectedIndex - 1,
                        DateOfBirth = dtpDOB.Value,
                        Email = tbEmail.Text,
                        ID = Convert.ToInt32(tbID.Text),
                        Photo = Helper.GetPhotoName(tbID.Text, imgPath),
                        Result = Helper.GetResultName(tbGivenName.Text, Resultpath),
                        Active = true,
                        ParentDetails = parent,
                        Phone = tbPhone.Text,
                        YearId = Years[cbYear.Text]
                    };

                    if (action.Equals(App.Action.Create))
                        Create(student);
                    else
                        Update(student);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, App.Error);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, App.Error + " Required fields cannot be empty");
            }
        }

        private void chkCloneAdress_CheckedChanged(object sender, EventArgs e)
        {
            tbPAddress.Enabled = !chkCloneAdress.Checked;
            if (tbPAddress.Enabled)
            {
                tbPAddress.Focus();
                tbPAddress.ResetText();
            }
            else
            {
                tbPAddress.Text = tbAddress.Text;
            }
        }

        private void picImgPath_DoubleClick(object sender, EventArgs e)
        {
            btnUpload.PerformClick();
        }
        private void ResultPath_DoubleClick(object sender, EventArgs e)
        {
            btnResult.PerformClick();
        }


        private void btnResult_Click(object sender, EventArgs e)
        {
            OpenFileDialog res = new OpenFileDialog()
            {
                Filter = "Supported (*.jpg)|*.jpg",
                Title = "Student Result"
            };

            if (res.ShowDialog().Equals(DialogResult.OK))
            {
                Resultpath = res.FileName;
               picResult.ImageLocation = Resultpath;
            }
        }
        private void Onlycharacter(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) || (e.KeyChar ==(char)Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
       
    }
}
