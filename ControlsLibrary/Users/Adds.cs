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

namespace ControlsLibrary.Users
{
    public partial class Adds : UserControl
    {
        private User User { get; set; }
        private App.Action action { get; set; }
        private string ImagePath { get; set; }

        public Adds(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                User = new User().Read(id);
                action = App.Action.Edit;
            }
            else
            {
                ImagePath = string.Empty;
            }
        }

        #region Custom Function
        private void Edit(User user)
        {
            if (User.Email.Equals(user.Email))
            {
                if (User.Phone.Equals(user.Phone))
                {
                    if (User.Username.Equals(user.Username))
                    {
                        user.Photo = Helper.GetPhotoName(user.Username, ImagePath);
                        PushEdits(user);
                    }
                    else
                    {
                        if (!user.Exists(user.Username))
                            PushEdits(user);
                        else
                            Helper.ShowMessage(lblStatus, "User with username already exist");
                    }
                }
                else
                {
                    if (!user.Exists(user.Phone))
                        PushEdits(user);
                    else
                        Helper.ShowMessage(lblStatus, "User with phone number already exist");
                }
            }
            else
            {
                if (!user.Exists(user.Email))
                    PushEdits(user);
                else
                    Helper.ShowMessage(lblStatus, "User with email already exist");
            }
        }

        private void PushEdits(User user)
        {
            if (!user.Password.Equals(User.Password))
                user.Password = App.PasswordHash(user.Password);

            bool updated = user.Update(user.ID);

            if (updated)
            {
                var oldPath = string.Format("{0}\\{1}", Helper.UploadPath, User.Photo);

                if (!oldPath.Equals(ImagePath))
                {
                    Helper.Unlink(oldPath);
                    Helper.Upload(user.Photo, ImagePath);
                }
                Helper.ClearFields(this);
                Helper.ShowMessage(lblStatus, "User Update successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating user info");
            }
        }

        private void Create(User user)
        {
            if (!user.Exists())
            {
                bool created = user.Create();

                if (created)
                {
                    Helper.Upload(user.Photo, ImagePath);
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lblStatus, "User Saved successfully", true);
                }
                else
                    Helper.ShowMessage(lblStatus, App.Error + "! Internal error occured");
            }
            else
            {
                Helper.ShowMessage(lblStatus, "User already created");
            }
        }

        private void PopulateType()
        {
            foreach (var typ in Enum.GetNames(typeof(App.UserType)))
            {
                cbUserType.Items.Add(typ);
            }
        }
       
        #endregion
        private void Adds_Load(object sender, EventArgs e)
        {
            PopulateType();

            if (action.Equals(App.Action.Create))
            {
                cbUserType.SelectedIndex = 0;
                cbGender.SelectedIndex = 0;
            }
            else
            {
                btnSave.Text = "Update Record";
                tbFullName.Text = User.Name;
                cbGender.Text = User.Gender.ToString();
                cbUserType.Text = User.UserType.ToString();
                tbAddress.Text = User.Address;
                tbPhone.Text = User.Phone;
                tbEmail.Text = User.Email;
                tbUsername.Text = User.Username;
                tbUsername.ReadOnly = true;
                tbPassword.Text = "********";
                tbConfirmPassword.Text = "********";
                tbPassword.ReadOnly = true;
                tbConfirmPassword.ReadOnly = true;
                chkShowPasswords.Enabled = false;
                pbUserPhoto.Image = Image.FromStream(Helper.PictureStream(User.Photo));
                ImagePath = string.Format("{0}\\{1}", Helper.UploadPath, User.Photo);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = Helper.FieldsCompleted(this);

            if (valid)
            {
                bool minMatch = Helper.FieldValid(this);

                if (minMatch)
                {
                    var isMatch = tbPassword.Text.Equals(tbConfirmPassword.Text);

                    if (isMatch)
                    {
                        User user = new User()
                        {
                            Name = tbFullName.Text,
                            Gender = (App.Gender)cbGender.SelectedIndex - 1,
                            Address = tbAddress.Text,
                            Email = tbEmail.Text,
                            Phone = tbPhone.Text,
                            Username = tbUsername.Text,
                            Password = tbPassword.Text,
                            Active = true,
                            UserType = (App.UserType)cbUserType.SelectedIndex - 1,
                            Photo = Helper.GetPhotoName(tbUsername.Text, ImagePath)
                        };

                        if (action.Equals(App.Action.Create))
                        {
                            Create(user);
                        }
                        else
                        {
                            user.ID = User.ID;
                            user.Active = User.Active;

                            if (user.Password.Equals("********"))
                                user.Password = User.Password;

                            Edit(user);
                        }
                    }
                    else
                    {
                        Helper.ShowMessage(lblStatus, "Passwords do not match");
                        tbPassword.Focus();
                    }
                }
                else
                {
                    Helper.ShowMessage(lblStatus, App.Error);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields cannot be empty");
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            chkShowPasswords.Enabled = !string.IsNullOrEmpty(tbPassword.Text);
        }

        private void chkShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = !chkShowPasswords.Checked;
            tbConfirmPassword.UseSystemPasswordChar = !chkShowPasswords.Checked;
        }

        private void pbUserPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog brw = new OpenFileDialog()
            {
                Title = "Select User Photo",
                Filter = "Supported (*.JPG, *.JPEG, *.PNG)|*.jpg;*.jpeg;*.png"
            };

            if (brw.ShowDialog().Equals(DialogResult.OK))
                ImagePath = brw.FileName;
            
            pbUserPhoto.Image = Image.FromFile(ImagePath);
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '+' || char.IsControl(e.KeyChar))

            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar));
        }
    }

}
