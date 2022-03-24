using SLMB_SMS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Year
    {
        #region Properties
        public int ID { get; set; }
        public string Period { get; set; }
        public Helper.Status Status { get; set; }
        public bool IsPayble { get; set; }
        private string Table { get { return "years"; } }
        private SqlConnection Connection {get;set;}
        #endregion

        public Year()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exists(string period = null)
        {
            period = !string.IsNullOrEmpty(period) ? period : Period;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.period = @period", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@period", period);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("INSERT INTO {0} VALUES(@period, @status, @paid)", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@paid", IsPayble);
                cmd.Parameters.AddWithValue("@period", Period);
                cmd.Parameters.AddWithValue("@status", Helper.Status.Enabled);

                Connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Year Read(int id)
        {
            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@id", id);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    ID = sdr.GetInt32(0);
                    Period = sdr.GetString(1);
                    Status = (Helper.Status)sdr.GetInt32(2);
                    IsPayble = sdr.GetInt32(3) > 0;

                    return this;
                }

                return null;
            }
        }

        public List<Year> Read()
        {
            using (Connection)
            {

                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    List<Year> years = new List<Year>();
                    
                    while (sdr.Read())
                    {
                        years.Add(new Year()
                        {
                            ID = sdr.GetInt32(0),
                            Period = sdr.GetString(1),
                            Status = (Helper.Status)sdr.GetInt32(2),
                            IsPayble = sdr.GetInt32(3) > 0
                        });
                    }

                    return years;
                }

                return null;
            }
        }

        public bool Update(Year year)
        {
            using (Connection)
            {
                string sql = string.Format("UPDATE {0} SET {0}.period = @period, {0}.status = @status, {0}.is_payable = @paid WHERE {0}.id=@id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@id", year.ID);
                cmd.Parameters.AddWithValue("@paid", year.IsPayble);
                cmd.Parameters.AddWithValue("@status", year.Status);
                cmd.Parameters.AddWithValue("@period", year.Period);

                Connection.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
