using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        void Fields_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string def = tb.Name.Substring(2, tb.Name.Length - 2);

            if (tb.Text.Equals(def))
                tb.ResetText();

            if (tb.Name.Contains("P"))
                tb.UseSystemPasswordChar = true;

            tb.ForeColor = Color.Black;
            tb.Font = new Font(tb.Font, FontStyle.Regular);
        }

        void Fields_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string def = tb.Name.Substring(2, tb.Name.Length - 2);

            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = def;
                tb.ForeColor = Color.Silver;
                tb.Font = new Font(tb.Font, FontStyle.Italic);

                if (tb.Name.Contains("P"))
                    tb.UseSystemPasswordChar = false;
            }
        }

        private void chkShowHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (!tbPassword.Text.ToLower().Equals("password"))
            {
                tbPassword.UseSystemPasswordChar = !chkShowHidePassword.Checked;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var isEmpty = tbUsername.ForeColor.Equals(Color.Silver) || tbPassword.ForeColor.Equals(Color.Silver);

            if (!isEmpty)
            {
                User user = new User().Login(tbUsername.Text);

                if (user != null)
                {
                    var isMatch = App.PasswordVerify(tbPassword.Text, user.Password);

                    if (isMatch)
                    {
                        App.Logged = user;
                        ParentForm.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Helper.ShowMessage(lbStatus, "Incorrect username or password");
                    }
                }
                else
                {
                    Helper.ShowMessage(lbStatus, "Incorrect username or password");
                }
            }
            else
            {
                Helper.ShowMessage(lbStatus, "Required fields not completed");
            }
        }

        private void lbForgotPassword_Click(object sender, EventArgs e)
        {
            var hasUsername = !tbUsername.ForeColor.Equals(Color.Silver);

            if (hasUsername)
            {
                User user = new User().Login(tbUsername.Text);

                if (user != null)
                {
                    lbStatus.Text = "Sending email....";
                    lbStatus.ForeColor = Color.CornflowerBlue;
                    int code = new Random().Next(111111, 999999);

                    Thread thrd = new Thread(new ThreadStart(() =>
                    {
                        var sent = new Mailer().Send(user.Email, user.Name, code);

                        if (sent)
                        {
                            user.Password = App.PasswordHash(code.ToString());
                            var updated = user.Update(user.ID);

                            if (updated)
                            {
                                if (lbStatus.InvokeRequired)
                                {
                                    lbStatus.Invoke((Action)delegate
                                    {
                                        Helper.ShowMessage(lbStatus, "Email sent. Check your mail box.", true);
                                    });
                                }
                                if (tbPassword.InvokeRequired)
                                {
                                    lbStatus.Invoke((Action)delegate
                                    {
                                        tbPassword.Focus();
                                    });
                                }
                            }
                        }
                        else
                        {
                            if (lbStatus.InvokeRequired)
                            {
                                lbStatus.Invoke((Action)delegate
                                {
                                    Helper.ShowMessage(lbStatus, App.Error);
                                });
                            }
                        }

                        Thread.CurrentThread.Abort();
                    }));

                    thrd.Start();
                }
                else
                {
                    Helper.ShowMessage(lbStatus, "Invalid username");
                }
            }
            else
            {
                Helper.ShowMessage(lbStatus, "Enter your username first");
            }
        }
    }
}
