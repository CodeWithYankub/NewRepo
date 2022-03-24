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
    public partial class ChangePassword : UserControl
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            tbConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var valid = Helper.FieldsCompleted(this);

            if (valid)
            {
                var isMinMatch = Helper.FieldValid(this);

                if (isMinMatch)
                {
                    var passMatch = tbConfirmPassword.Text.Equals(tbNewPassword.Text);

                    if (passMatch)
                    {
                        User user = new User().Read(App.Logged.ID);

                        if (user != null)
                        {
                            user.Password = App.PasswordHash(tbNewPassword.Text);

                            var updated = user.Update(user.ID);

                            if (!updated)
                                Helper.ShowMessage(lbStatus, App.Error);
                            else
                            {
                                App.Logged = new User().Read(user.ID);
                                ParentForm.DialogResult = DialogResult.OK;
                            }
                        }
                    }
                    else
                    {
                        Helper.ShowMessage(lbStatus, "Passwords do not match");
                    }
                }
                else
                {
                    Helper.ShowMessage(lbStatus, App.Error);
                }
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
