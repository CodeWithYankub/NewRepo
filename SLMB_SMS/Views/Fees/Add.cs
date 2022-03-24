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

namespace SLMB_SMS.Views.Fees
{
    public partial class Add : UserControl
    {
        private Helper.Action Action { get; set; }
        private Fee Fee { get; set; }
        private Dictionary<string, int> Years { get; set; }
        public Add(int id = 0)
        {
            InitializeComponent();

            if (id > 0)
            {
                Action = Helper.Action.Update;
                Fee = new Fee().Read(id);
            }

            Years = new Dictionary<string, int>();
        }

        #region Custom Functions
        void fetchYears()
        {
            List<Year> years = new Year().Read();

            if (years.Count > 0)
            {
                Years.Clear();
                cbYear.Items.Clear();
                cbYear.Items.Add("--- select ---");
            }

            foreach (Year year in years)
            {
                if(year.Status.Equals(Helper.Status.Enabled))
                {
                    cbYear.Items.Add(year.Period);
                    Years.Add(year.Period, year.ID);
                }
            }

            cbYear.SelectedIndex = 0;
        }

        void Create(Fee fee)
        {
            if (!fee.Exists())
            {
                bool created = fee.Create();

                if (created)
                {
                    Helper.ShowMessage(lblStatus, "Fee saved successfully", true);

                    // reset form
                    cbYear.SelectedIndex = 0;
                    tbReceipt.ResetText();
                    tbStudentID.ResetText();
                    tbAmount.ResetText();
                    tbTerm.ResetText();
                    chkIsFull.Checked = false;
                    tbReceipt.Focus();
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Error saving fee");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Fee already exists");
                tbReceipt.Focus();
            }
        }

        void Edit(Fee fee)
        {
            if (Fee.ID.Equals(fee.ID))
            {
                PushEdits(fee);
            }
            else
            {
                if (!fee.Exists())
                {
                    PushEdits(fee);
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Fee already exist");
                }
            }
        }
        void PushEdits(Fee fee)
        {
            bool updated = new Fee().Update(fee);

            if (updated)
            {
                Helper.ShowMessage(lblStatus, "Fee updated successfully", true);
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Error updating fee");
            }
        }
        #endregion

        private void Add_Load(object sender, EventArgs e)
        {
            fetchYears();

            if (Action.Equals(Helper.Action.Update))
            {
                Year year = new Year().Read(Fee.Year);
                tbReceipt.Text = Fee.ID.ToString();
                tbStudentID.Text = Fee.Student.ToString();
                cbYear.Text = year.Period;
                tbAmount.Text = Fee.Amount.ToString();
                chkIsFull.Checked = Fee.IsFull;
                tbTerm.Text = Fee.Terms;
                dpDatePaid.Value = Fee.DatePaid;

                tbReceipt.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var filled = Helper.FieldsCompleted(this);

            if (filled)
            {
                var valid_student = new Student().Read(int.Parse(tbStudentID.Text));

                if (valid_student != null)
                {
                    Fee fee = new Fee()
                    {
                        ID = int.Parse(tbReceipt.Text),
                        Student = int.Parse(tbStudentID.Text),
                        Year = Years[cbYear.Text],
                        IsFull = chkIsFull.Checked,
                        Terms = tbTerm.Text,
                        Amount = decimal.Parse(tbAmount.Text),
                        DatePaid = dpDatePaid.Value
                    };

                    if (Action.Equals(Helper.Action.Update))
                    {
                        fee.ID = Fee.ID;
                        Edit(fee);
                    }
                    else
                    {
                        Create(fee);
                    }
                }
                else
                {
                    Helper.ShowMessage(lblStatus, "Invalid student #ID");
                }
            }
            else
            {
                Helper.ShowMessage(lblStatus, "Required fields not completed");
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex > 0)
            {
                Year year = new Year().Read(Years[cbYear.Text]);

                if (year != null)
                {
                    tbAmount.Text = "0.00";
                    tbAmount.ReadOnly = !year.IsPayble;
                    chkIsFull.Checked = !year.IsPayble;
                    chkIsFull.Enabled = year.IsPayble;
                }
            }
        }
    }
}
