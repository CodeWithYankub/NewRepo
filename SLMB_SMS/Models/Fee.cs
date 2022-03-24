using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Fee
    {
        #region Properties
        public int ID { get; set; }
        public int Student { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public bool IsFull { get; set; }
        public string Terms { get; set; }
        public DateTime DatePaid { get; set; }

        private string Table { get { return "fees"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public Fee()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exists()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", ID);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@id, @student, @year, @amount, @isfull, @term, @date)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@student", Student);
                cmd.Parameters.AddWithValue("@year", Year);
                cmd.Parameters.AddWithValue("@amount", Amount);
                cmd.Parameters.AddWithValue("@isfull", IsFull);
                cmd.Parameters.AddWithValue("@term", Terms);
                cmd.Parameters.AddWithValue("@date", DatePaid);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Fee Read(int id)
        {
            using (Connection)
            {
                string strSql = string.Format
                    ("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", id);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    ID = sdr.GetInt32(0);
                    Student = sdr.GetInt32(1);
                    Year = sdr.GetInt32(2);
                    Amount = sdr.GetDecimal(3);
                    IsFull = sdr.GetInt32(4) > 0;
                    Terms = sdr.GetString(5);
                    DatePaid = sdr.GetDateTime(6);

                    return this;
                }

                return null;
            }
        }

        public List<Fee> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Fee> fees = new List<Fee>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        fees.Add(new Fee()
                        {
                            ID = sdr.GetInt32(0),
                            Student = sdr.GetInt32(1),
                            Year = sdr.GetInt32(2),
                            Amount = sdr.GetDecimal(3),
                            IsFull = sdr.GetInt32(4) > 0,
                            Terms = sdr.GetString(5),
                            DatePaid = sdr.GetDateTime(6)
                        });
                    }
                }

                return fees;
            }
        }

        public bool Update(Fee fee)
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("UPDATE {0} SET {0}.student_id = @student, {0}.year_id = @year, {0}.amount = @amount, {0}.is_full = @isfull, {0}.terms = @terms, {0}.date_paid = @date WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);

                /* Define paramaeters */
                {
                    cmd.Parameters.AddWithValue("@id", fee.ID);
                    cmd.Parameters.AddWithValue("@student", fee.Student);
                    cmd.Parameters.AddWithValue("@year", fee.Year);
                    cmd.Parameters.AddWithValue("@amount", fee.Amount);
                    cmd.Parameters.AddWithValue("@isfull", fee.IsFull);
                    cmd.Parameters.AddWithValue("@terms", fee.Terms);
                    cmd.Parameters.AddWithValue("@date", fee.DatePaid);

                }

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;

            }
        }

        public List<Fee> Search(string key = null)
        {
            key = string.IsNullOrEmpty(key) ? Student.ToString() : key;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.student_id LIKE @key OR {0}.id LIKE @key", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@key", string.Format("%{0}%", key));

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                List<Fee> fees = new List<Fee>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        fees.Add(new Fee()
                        {
                            ID = sdr.GetInt32(0),
                            Student = sdr.GetInt32(1),
                            Year = sdr.GetInt32(2),
                            Amount = sdr.GetDecimal(3),
                            IsFull = sdr.GetInt32(4) > 0,
                            Terms = sdr.GetString(5),
                            DatePaid = sdr.GetDateTime(6)
                        });
                    }
                }
                 return fees;

            }
        }

    }
}
