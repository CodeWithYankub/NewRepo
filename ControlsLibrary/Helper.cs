using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary
{
    public static class Helper
    {
        public static string GetAcronym(string strs)
        {
            string[] vs = strs.Split(' ');
            string acronym = string.Empty;
            string[] exceptions = new string[] { "secondary", "school", "sector" };

            foreach (string word in vs)
            {
                if (!exceptions.Contains(word.ToLower()))
                {
                    if (!string.IsNullOrEmpty(word))
                        acronym += word[0];
                }
            }

            return string.Format("{0}SS", acronym);
        }

        public static bool FieldValid(Control parent)
        {
            var completed = parent.Controls.Count > 0;

            foreach (Control ctrl in parent.Controls)
            {
                string name = ctrl.Name.Substring(2, ctrl.Name.Length - 2);

                // Validate required fields
                if (ctrl.Tag != null)
                {
                    string tag = ctrl.Tag.ToString();

                    if (tag.Length > 1)
                    {
                        int min = Convert.ToInt32(tag.Split('*')[1]);

                        if (ctrl.Text.Length < min)
                        {
                            name = name.Contains("Confirm") ? "Password" : name;

                            App.Error = string.Format("{0} must be at least {1} characters", name, min);
                            completed = false;
                            break;
                        }
                    }
                }

                // Validate email
                if (ctrl.Name.ToLower().Contains("email"))
                {
                    if (!string.IsNullOrEmpty(ctrl.Text))
                    {
                        try
                        {
                            var isEmail = new System.Net.Mail.MailAddress(ctrl.Text);
                        }
                        catch
                        {
                            App.Error = string.Format("{0} is invalid", name);
                            completed = false;
                            break;
                        }
                    }
                }
            }

            return completed;
        }

        public static bool FieldsCompleted(Control control)
        {
            bool completed = control.Controls.Count > 0;

            if (completed)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl.Tag != null)
                    {
                        if (ctrl is TextBox)
                        {
                            TextBox tb = (TextBox)ctrl;
                            if (string.IsNullOrEmpty(tb.Text))
                            {
                                completed = false;
                                break;
                            }
                        }
                        else if (ctrl is ComboBox)
                        {
                            ComboBox cb = (ComboBox)ctrl;

                            if (cb.SelectedIndex < 1)
                            {
                                completed = false;
                                break;
                            }
                        }
                        else if (ctrl is PictureBox)
                        {
                            PictureBox pb = (PictureBox)ctrl;

                            if (pb.Image == null)
                            {
                                completed = false;
                                break;
                            }
                        }
                        else if (ctrl is CheckBox)
                        {
                            CheckBox chk = (CheckBox)ctrl;

                            if (!chk.Checked)
                            {
                                completed = false;
                                break;
                            }
                        }
                        else if (ctrl is DateTimePicker)
                        {
                            DateTimePicker dtp = (DateTimePicker)ctrl;

                            if (string.IsNullOrEmpty(dtp.Value.ToString()))
                            {
                                completed = false;
                                break;
                            }
                        }
                        else if (ctrl is Panel)
                        {
                            FieldsCompleted(ctrl);
                        }
                        else if (ctrl is GroupBox)
                        {
                            FieldsCompleted(ctrl);
                        }
                    }

                }
            }

            if (!completed)
                App.Error = "Required field(s) can not be empty";

            return completed;
        }

        public static void Resize(ListView sender)
        {
            const double per = 100.00;
            double width = sender.Width;
            double count = sender.Columns.Count;

            for (int i = 0; i < sender.Columns.Count; i++)
            {
                ColumnHeader ch = sender.Columns[i];

                if (ch.Text.Contains("#"))
                {
                    count -= 1;
                    width -= 35;
                    ch.Width = 35;
                }
                else
                {
                    var percent = per / count;
                    ch.Width = Convert.ToInt32(percent / per * (width));
                }

            }
        }

        public static string ToRomans(int number)
        {
            string[] romans = new string[] { "I", "II", "III", "IV", "V", "VI" };
            return romans[number - 1];
        }

        public static void ShowMessage(Label lbl, string msg, bool success = false)
        {
            lbl.ForeColor = !success ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            lbl.Text = msg;

            Timer timer = new Timer()
            {
                Interval = 5000
            };

            timer.Start();

            timer.Tick += (object sender, EventArgs e) =>
            {
                lbl.ResetText();
                timer.Stop();
                timer.Dispose();
            };
        }
        public static string UploadPath
        {
            get
            {
                return string.Format(@"{0}Images", Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("bin")));
            }
        }
        public static void Unlink(string file)
        {
            File.Delete(file);
        }

        public static MemoryStream PictureStream(string photo)
        {
            string photoPath = string.Format(@"{0}\{1}", UploadPath, photo);
            using (FileStream fs = File.OpenRead(photoPath))
            {
                byte[] byts = new byte[fs.Length];
                fs.Read(byts, 0, byts.Length);

                return new MemoryStream(byts, 0, byts.Length);
            }
        }

        public static void ClearFields(Control ctrl)
        {
            foreach(Control ct in ctrl.Controls)
            {
                if(ct is TextBox)
                {
                    ct.ResetText();
                }else if(ct is ComboBox)
                {
                    ComboBox cb = (ComboBox)ct;
                    cb.SelectedIndex = 0;
                }else if(ct is PictureBox)
                {
                    PictureBox pb = (PictureBox)ct;
                    pb.ImageLocation = string.Empty;
                    pb.Image = null;

                    pb.Invalidate();
                }else if(ct is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)ct;
                    dtp.ResetText();
                }
            }
        }

        public static string GetPhotoName(string uid, string file)
        {
            FileInfo fi = new FileInfo(file);
            string fileName = string.Format("{0}{1}", uid, fi.Extension);

            return fileName;
        }
        public static MemoryStream ResultStream(string result)
        {
            string Resultpath = string.Format(@"{0}\{1}", UploadPath, result);
            using (FileStream fs = File.OpenRead(Resultpath))
            {
                byte[] byts = new byte[fs.Length];
                fs.Read(byts, 0, byts.Length);

                return new MemoryStream(byts, 0, byts.Length);
            }
        }
        public static string GetResultName(string uid, string file)
        {
            FileInfo fi = new FileInfo(file);
            string fileName = string.Format("{0}{1}", uid, fi.Extension);

            return fileName;
        }

        public static string Upload(string fileName, string file)
        {
            FileInfo fi = new FileInfo(file);
            string filePath = string.Format(@"{0}\{1}", UploadPath, fileName);


            if (!filePath.Equals(file))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    byte[] fileBytes = File.ReadAllBytes(file);
                    fs.Write(fileBytes, 0, fileBytes.Length);
                }
            }

            return filePath;
        }
    }
}