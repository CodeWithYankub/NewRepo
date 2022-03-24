using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Fee
    {
        #region Properties
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public decimal Amount { get; set; }
        public bool Completed { get; set; }
        public string Terms { get; set; }
        public DateTime PaidOn { get; set; }
        public int PaidTo { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Fees"; } }
        #endregion

        public Fee()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Id=@id OR StudentId=@student AND YearId=@year", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@student", StudentId);
                    cmd.Parameters.AddWithValue("@year", YearId);
                    cmd.Parameters.AddWithValue("@id", ID);

                    Connection.Open();

                    return cmd.ExecuteReader().HasRows;
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }

        // Create a new record
        public bool Create()
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("INSERT INTO {0} VALUES(@id, @student, @year, @amount, @completed, @terms, @paidon, @paidto)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@student", StudentId);
                        cmd.Parameters.AddWithValue("@year", YearId);
                        cmd.Parameters.AddWithValue("@amount", Amount);
                        cmd.Parameters.AddWithValue("@completed", Completed);
                        cmd.Parameters.AddWithValue("@terms", Terms);
                        cmd.Parameters.AddWithValue("@paidon", DateTime.Now);
                        cmd.Parameters.AddWithValue("@paidto", App.Logged.ID);
                    }

                    Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }

        // Fetch all records
        public List<Fee> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} ORDER BY {0}.YearId ASC", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Fee> fees = new List<Fee>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            fees.Add(new Fee()
                            {
                                ID = sdr.GetInt32(0),
                                StudentId = sdr.GetInt32(1),
                                YearId = sdr.GetInt32(2),
                                Amount = sdr.GetDecimal(3),
                                Completed = sdr.GetBoolean(4),
                                Terms = sdr.GetString(5),
                                PaidOn = sdr.GetDateTime(6),
                                PaidTo = sdr.GetInt32(7),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return fees;
            }
        }

        // Fetch a specified record
        public Fee Read(int id)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();

                        return new Fee()
                        {
                            ID = sdr.GetInt32(0),
                            StudentId = sdr.GetInt32(1),
                            YearId = sdr.GetInt32(2),
                            Amount = sdr.GetDecimal(3),
                            Completed = sdr.GetBoolean(4),
                            Terms = sdr.GetString(5),
                            PaidOn = sdr.GetDateTime(6),
                            PaidTo = sdr.GetInt32(7),
                        };
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return null;
            }
        }

        // Update a specified record
        public bool Update(int id)
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("UPDATE {0} SET StudentId=@student, YearId=@year, Amount=@amount, Completed=@completed, Terms=@terms WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@student", StudentId);
                        cmd.Parameters.AddWithValue("@year", YearId);
                        cmd.Parameters.AddWithValue("@amount", Amount);
                        cmd.Parameters.AddWithValue("@completed", Completed);
                        cmd.Parameters.AddWithValue("@terms", Terms);
                    }

                    Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }
    }
}
