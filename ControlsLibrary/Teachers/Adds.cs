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

namespace ControlsLibrary.Teachers
{
    public partial class Adds : UserControl
    {
        private Teacher Teacher { get; set; }
        private App.Action action { get; set; }
        Dictionary<string, int> Sectors { get; set; }

        public Adds(int id = 0)
        {
            InitializeComponent();

            Sectors = new Dictionary<string, int>();

            if (id > 0)
            {
                Teacher = new Teacher().Read(id);
                action = App.Action.Edit;
            }
        }

        #region Custom Function
        private void fechSectors()
        {
            List<Sector> sectors = new Sector().Read();
            foreach (Sector sector in sectors)
            {
                Sectors.Add(sector.Name, sector.ID);
                cbSector.Items.Add(sector.Name);
            }
        }
        private void Edit(Teacher teacher)
        {
            if (Teacher.PinCode.Equals(teacher.PinCode))
            {
                if (Teacher.SectorId.Equals(teacher.SectorId))
                {
                    PushEdits(teacher);
                }
                else
                {
                    if (!teacher.Exists("SectorId", teacher.SectorId))
                        PushEdits(teacher);
                    else
                        Helper.ShowMessage(lblStatus, "Teacher already exist");
                }
            }
            else
            {
                if (!teacher.Exists("PinCode", teacher.PinCode))
                    PushEdits(teacher);
                else
                    Helper.ShowMessage(lblStatus, "Teacher already exist");
            }
        }

        private void PushEdits(Teacher teacher)
        {
            bool updated = teacher.Update(Teacher.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lblStatus, "Teacher upated successfully", true);
            }
            else
                Helper.ShowMessage(lblStatus, "Error updating teacher");
        }

        private void Create(Teacher teacher)
        {
            if (!teacher.Exists())
            {
                bool created = teacher.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lblStatus, "Teacher saved successfully", true);
                }
                else
                    Helper.ShowMessage(lblStatus, "Internal error occured");
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Teacher already added");
            }
        }
        private void OnlyCharacter(object sender, KeyPressEventArgs e)
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
        private void OnlyNumber(object sender, KeyPressEventArgs e)
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
        #endregion
        private void Adds_Load(object sender, EventArgs e)
        {
            fechSectors();

            /* Cast dates */
            {
                dtpEmployedOn.MaxDate = DateTime.Now.Date;
            }

            if (action.Equals(App.Action.Create))
            {
                cbSector.SelectedIndex = 0;
                cbGender.SelectedIndex = 0;
            }
            else
            {
                Sector sector = new Sector().Read(Teacher.SectorId);
                tbAddress.Text = Teacher.Address;
                tbEmail.Text = Teacher.Email;
                tbPhone.Text = Teacher.Phone;
                tbPinCode.Text = Teacher.PinCode.ToString();
                tbTName.Text = Teacher.Name;
                cbSector.Text = sector != null ? sector.Name : "";
                cbGender.Text = Teacher.Gender.ToString();

                tbNKAddress.Text = Teacher.NextOfKin.Address;
                tbNKEmail.Text = Teacher.NextOfKin.Email;
                tbNkPhone.Text = Teacher.NextOfKin.Phone;
                tbNKRelation.Text = Teacher.NextOfKin.Relationship;
                tbNKname.Text = Teacher.NextOfKin.Name;

                btnSave.Text = "Update Record";
                chkCloneAdress.Checked = Teacher.Address.Equals(Teacher.NextOfKin.Address);
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
                    Teacher.Kin kin = new Teacher.Kin()
                    {
                        Name = tbNKname.Text,
                        Address = tbNKAddress.Text,
                        Phone = tbNkPhone.Text,
                        Email = tbNKEmail.Text,
                        Relationship = tbNKRelation.Text
                    };

                    Teacher teacher = new Teacher()
                    {
                        SectorId = Sectors[cbSector.Text],
                        PinCode = Convert.ToInt64(tbPinCode.Text),
                        Name = tbTName.Text,
                        Gender = (App.Gender)cbGender.SelectedIndex - 1,
                        Address = tbAddress.Text,
                        Email = tbEmail.Text,
                        Phone = tbPhone.Text,
                        Approved = true,
                        EmployedOn = dtpEmployedOn.Value,
                        NextOfKin = kin
                    };

                    if (action.Equals(App.Action.Create))
                    {
                        Create(teacher);
                    }
                    else
                    {
                        teacher.ID = Teacher.ID;
                        Edit(teacher);
                    }
                }
                else
                {
                    Helper.ShowMessage(lblStatus, App.Error);
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, App.Error);
            }
        }
        private void chkCloneAdress_CheckedChanged(object sender, EventArgs e)
        {
            tbNKAddress.Enabled = !chkCloneAdress.Checked;
            if (tbNKAddress.Enabled)
            {
                tbNKAddress.Focus();
                tbNKAddress.ResetText();
            }
            else
            {
                tbNKAddress.Text = tbAddress.Text;
            }
        }

        private void chkCloneAdress_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbAddress.Text))
            {
                if (chkCloneAdress.Checked)
                {
                    tbNKAddress.Enabled = false;
                    tbNKAddress.Text = tbAddress.Text;
                }
                else
                {
                    tbNKAddress.ResetText();
                    tbNKAddress.Enabled = true;
                }
            }
            else
            {
                chkCloneAdress.Checked = false;
            }
        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {
            if (chkCloneAdress.Checked)
            {
                tbNKAddress.Text = tbAddress.Text;
            }
        }

        private void tbTName_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
