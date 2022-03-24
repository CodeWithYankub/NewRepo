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

namespace ControlsLibrary.Fees
{
    public partial class Add : UserControl
    {
        private Fee Fee { get; set; }
        private decimal SectorFee { get; set; }
        private decimal TotalPaid { get; set; }
        private App.Action Action { get; set; }

        private Dictionary<string,int> Years { get; set; }
        public Add(App.Action action = App.Action.Create, int id = 0)
        {
            InitializeComponent();

            Action = action;
            Years = new Dictionary<string, int>();

            if (id > 0)
                Fee = new Fee().Read(id);
        }

        #region Functions
        void GetYears()
        {
            List<Year> years = new Year().Read();

            if (cbYear.Items.Count > 0)
                cbYear.Items.Clear();

            cbYear.Items.Add("--- select ---");
            Years.Clear();

            foreach(Year year in years)
            {
                if (year.Opened)
                {
                    cbYear.Items.Add(year.Period);
                    Years.Add(year.Period, year.ID);
                }
            }

            cbYear.SelectedIndex = 0;
        }

        void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Fee fee = new Fee()
                {
                    ID = Convert.ToInt32(tbReceiptNo.Text),
                    YearId = Years[cbYear.Text],
                    StudentId = Convert.ToInt32(tbStudentID.Text),
                    Amount = TotalPaid,
                    Completed = chbPaidFull.Checked,
                    Terms = tbTerm.Text
                };

                if (new Student().Exists(fee.StudentId))
                {
                    if (Action.Equals(App.Action.Create))
                        Create(fee);
                    else
                        Update(fee);
                }
                else
                {
                    Helper.ShowMessage(lbError, "Invalid student Id");
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void doUpdates(Fee fee)
        {
            var updated = fee.Update(Fee.ID);

            if (updated)
            {
                Helper.ClearFields(this);
                Helper.ShowMessage(lbError, "Fee Updated Successfully", true);
            }
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Fee fee)
        {
            if (fee.ID.Equals(Fee.ID))
            {
                doUpdates(fee);
            }
            else
            {
                if (!fee.Exists())
                    doUpdates(fee);
                else
                    Helper.ShowMessage(lbError, "Fee already exists");
            }
        }

        private void Create(Fee fee)
        {
            if (!fee.Exists())
            {
                var created = fee.Create();

                if (created)
                {
                    Helper.ClearFields(this);
                    Helper.ShowMessage(lbError, "Fee Saved Successfully", true);
                }
                else
                    Helper.ShowMessage(lbError, App.Error);
            }
            else
            {
                Helper.ShowMessage(lbError, "Fee already paid");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetYears();
            cbSector.SelectedIndex = 0;

            if (Action.Equals(App.Action.Edit))
            {
                Year year = new Year().Read(Fee.YearId);
                cbYear.Text = year.Period;
                tbReceiptNo.Text = Fee.ID.ToString();
                tbStudentID.Text = Fee.StudentId.ToString();
                tbAmount.Text = Fee.Amount.ToString("#,##0");
                tbTerm.Text = Fee.Terms;
                chbPaidFull.Checked = Fee.Completed;
                tbReceiptNo.Enabled = false;

                btnSave.Text = "Update Record";
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex > 0)
            {
                Year year = new Year().Read(Years[cbYear.Text]);

                if (!year.Paid)
                {
                    tbAmount.Text = "0";
                    tbAmount.Enabled = false;

                    tbTerm.Text = "All";
                    tbTerm.Enabled = false;

                    chbPaidFull.Checked = true;
                    chbPaidFull.Enabled = false;
                }
            }
        }

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            PaymentDetails();
        }

        private void PaymentDetails()
        {
            if (!string.IsNullOrEmpty(tbStudentID.Text) && !string.IsNullOrEmpty(tbAmount.Text))
            {
                decimal paid = 0;
                int year = Years[cbYear.Text];
                decimal amount = Convert.ToDecimal(tbAmount.Text);
                int studentId = Convert.ToInt32(tbStudentID.Text);
                List<Fee> fees = new Fee().Read().FindAll(fee => fee.StudentId.Equals(studentId) && fee.YearId.Equals(year));

                foreach (Fee fee in fees)
                {
                    paid += fee.Amount;
                }

                paid += amount;
                TotalPaid = paid;
                var div = Math.Floor(paid / (SectorFee / 3));

                lbBalance.Text = string.Format("Paid: {0:0,00} Balance: Le{1:0,000}", paid, SectorFee - paid);
                tbTerm.Text = div.Equals(3) ? "All" : div.ToString();
                chbPaidFull.Checked = div.Equals(3);
            }
            else
            {
                lbBalance.ResetText();
            }
        }

        private void cbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectorFee = cbSector.SelectedIndex > 1 ? 135000 : 105000;

            PaymentDetails();
        }
    }
}
