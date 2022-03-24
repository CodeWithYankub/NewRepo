using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Year
    {
        #region Properties
        public int ID { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string Period { get; set; }
        public bool Opened { get; set; }
        public bool Paid { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Years"; } }
        #endregion

        public Year()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Start=@start", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@start", Start);

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
                string query = string.Format("INSERT INTO {0} VALUES(@start, @end, @period, @opened, @paid)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@start", Start);
                        cmd.Parameters.AddWithValue("@end", End);
                        cmd.Parameters.AddWithValue("@period", Period);
                        cmd.Parameters.AddWithValue("@opened", Opened);
                        cmd.Parameters.AddWithValue("@paid", Paid);
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
        public List<Year> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} ORDER BY Start ASC", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Year> years = new List<Year>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {

                        while (sdr.Read())
                        {
                            years.Add(new Year()
                            {
                                ID = sdr.GetInt32(0),
                                Start = sdr.GetInt32(1),
                                End = sdr.GetInt32(2),
                                Period = sdr.GetString(3),
                                Opened = sdr.GetBoolean(4),
                                Paid = sdr.GetBoolean(5),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return years;
            }
        }

        // Fetch a specified record
        public Year Read(int id)
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

                        return new Year()
                        {
                            ID = sdr.GetInt32(0),
                            Start = sdr.GetInt32(1),
                            End = sdr.GetInt32(2),
                            Period = sdr.GetString(3),
                            Opened = sdr.GetBoolean(4),
                            Paid = sdr.GetBoolean(5),
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
                string query = string.Format("UPDATE {0} SET Start=@start, [End]=@end, Period=@period, Opened=@opened, Paid=@paid WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@start", Start);
                        cmd.Parameters.AddWithValue("@end", End);
                        cmd.Parameters.AddWithValue("@period", Period);
                        cmd.Parameters.AddWithValue("@opened", Opened);
                        cmd.Parameters.AddWithValue("@paid", Paid);
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
