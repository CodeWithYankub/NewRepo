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
    public partial class Admit : UserControl
    {
        private string imgPath { get; set; }
        private Student Student { get; set; }
        private Helper.Action action { get; set; }
        public Admit(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Student = new Student().Read(id);
                action = Helper.Action.Update;
            }
        }

        #region Custom Function
        private bool ValidateFields()
        {
            bool valid = true;
            foreach(Control ctrl in Controls)
            {
                if(ctrl.GetType().Equals(new GroupBox().GetType()))
                {
                    GroupBox gpb = (GroupBox)ctrl;

                    foreach(Control ct in gpb.Controls)
                    {
                        if (ct.GetType().Equals(new TextBox().GetType()))
                        {
                            TextBox tb = (TextBox)ct;
                            bool exp = tb.Name.ToLower().Contains("email") || tb.Name.ToLower().Contains("other");
                            if (string.IsNullOrEmpty(tb.Text) && !exp)
                            {
                                valid = false;
                                break;
                            }
                        }else if (ct.GetType().Equals(new ComboBox().GetType()))
                        {
                            ComboBox cb = (ComboBox)ct;

                            if (cb.SelectedIndex < 1)
                            {
                                valid = false;
                                break;
                            }
                        }else if (ct.GetType().Equals(new PictureBox().GetType()))
                        {
                            PictureBox pb = (PictureBox)ct;

                            if (pb.Image == null)
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                }
            }
            return valid;
        }

        void Edit(Student student)
        {
            if (Student.ID.Equals(student.ID))
            {
                PushEdits(student);
            }
            else
            {
                if (!student.Exists())
                {
                    PushEdits(student);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Sector name already exist");
                }
            }
        }

        void PushEdits(Student student)
        {
            bool updated = new Student().Update(student);

            if (updated)
            {
                Helper.ShowMessage(lblStatus, "Student updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating student");
            }
        }

        void Create(Student student)
        {
            if (!student.Exists())
            {
                bool created = student.Create();

                if (created)
                    ShowMessage(true, "Student admitted successfully");
                else
                    ShowMessage(false, "Internal error occured");
            }
            else
            {
                ShowMessage(false, "Student already admitted");
            }
        }

        private void ShowMessage(bool success, string message)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = success ? Color.Green : Color.Red;

            Timer timer = new Timer() { Interval = 4000 };
            timer.Start();
            timer.Tick += (object sender, EventArgs e) =>
            {
                lblStatus.ResetText();
            };
        }
        #endregion

        private void Admit_Load(object sender, EventArgs e)
        {
            if (action.Equals(Helper.Action.Create))
            {
                cbColor.SelectedIndex = 0;
                cbGender.SelectedIndex = 0;
            }
            else
            {

                imgPath = Student.Image;
                tbAddress.Text = Student.Address;
                tbEmail.Text = Student.Email;
                tbSurname.Text = Student.LastName;
                tbGivenName.Text = Student.FirstName;
                tbOtherName.Text = Student.OtherName;
                tbID.Text = Student.ID.ToString();
                tbPhone.Text = Student.PhoneNo;
                tbPName.Text = Student.ParentName;
                tbPPhone.Text = Student.ParentPhone;
                tbPEmail.Text = Student.ParentEmail;
                tbPAddress.Text = Student.ParentAddress;
                tbOccupation.Text = Student.ParentOccuption;
                tbRelation.Text = Student.ParentRelationShip;
                cbGender.Text = Student.Gender.ToString();
                cbColor.Text = Student.Color.ToString();
                dtpAdmitted.Value = Student.AddmisionDate;
                dtpDOB.Value = Student.DateOfBirth;

                picImgPath.Image = Image.FromStream(Helper.PictureStream(Student.Image));

                chkCloneAdress.Checked = Student.Address.Equals(Student.ParentAddress);
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
                picImgPath.Image = Image.FromFile(imgPath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = ValidateFields();

            if (valid)
            {
                Student student = new Student()
                {
                    FirstName = tbGivenName.Text,
                    LastName = tbSurname.Text,
                    OtherName = tbOtherName.Text,
                    Gender = (Helper.Gender)cbGender.SelectedIndex - 1,
                    AddmisionDate = dtpAdmitted.Value,
                    Address = tbAddress.Text,
                    Color = (Helper.Colour)cbColor.SelectedIndex - 1,
                    DateOfBirth = dtpDOB.Value,
                    Email = tbEmail.Text,
                    ID = Convert.ToInt32(tbID.Text),
                    Image = imgPath,
                    IsActive = true,
                    ParentAddress = tbPAddress.Text,
                    ParentEmail = tbPEmail.Text,
                    ParentName = tbPName.Text,
                    ParentOccuption = tbOccupation.Text,
                    ParentPhone = tbPPhone.Text,
                    ParentRelationShip = tbRelation.Text,
                    PhoneNo = tbPhone.Text
                };
                
                if (action.Equals(Helper.Action.Create))
                    Create(student);
                else
                    Edit(student);
            }
            else
            {
                ShowMessage(false, "Required fields cannot be empty");
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
    }
}
