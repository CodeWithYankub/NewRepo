using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Registration
    {
        #region Properties
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int YearId { get; set; }
        public int StreamId { get; set; }
        public int FeeId { get; set; }
        public DateTime RegisteredOn { get; set; }
        public int RegisteredBy { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Registrations"; } }
        #endregion

        public Registration()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE FeeId=@fee OR (StudentId=@student AND YearId=@year)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@student", StudentId);
                    cmd.Parameters.AddWithValue("@year", YearId);

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
        public int Create()
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("INSERT INTO {0} VALUES(@student, @year, @stream, @fee, @registeredon, @registeredby); SELECT SCOPE_IDENTITY()", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@student", StudentId);
                        cmd.Parameters.AddWithValue("@year", YearId);
                        cmd.Parameters.AddWithValue("@stream", StreamId);
                        cmd.Parameters.AddWithValue("@fee", FeeId);
                        cmd.Parameters.AddWithValue("@registeredon", DateTime.Now);
                        cmd.Parameters.AddWithValue("@registeredby", App.Logged.ID);
                    }

                    Connection.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                    return 0;
                }
            }
        }

        // Fetch all records
        public List<Registration> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Registration> registrations = new List<Registration>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            registrations.Add(new Registration()
                            {
                                ID = sdr.GetInt32(0),
                                StudentId = sdr.GetInt32(1),
                                YearId = sdr.GetInt32(2),
                                StreamId = sdr.GetInt32(3),
                                FeeId = sdr.GetInt32(4),
                                RegisteredOn = sdr.GetDateTime(5),
                                RegisteredBy = sdr.GetInt32(6),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return registrations;
            }
        }

        // Fetch a specified record
        public Registration Read(int id)
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

                        return new Registration()
                        {
                            ID = sdr.GetInt32(0),
                            StudentId = sdr.GetInt32(1),
                            YearId = sdr.GetInt32(2),
                            StreamId = sdr.GetInt32(3),
                            FeeId = sdr.GetInt32(4),
                            RegisteredOn = sdr.GetDateTime(5),
                            RegisteredBy = sdr.GetInt32(6),
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
                string query = string.Format("UPDATE {0} SET StudentId=@student, YearId=@year, StreamId=@stream, FeeId=@fee WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@student", StudentId);
                        cmd.Parameters.AddWithValue("@year", YearId);
                        cmd.Parameters.AddWithValue("@stream", StreamId);
                        cmd.Parameters.AddWithValue("@fee", FeeId);
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

        // Delete a specified record
        public bool Delete(int id)
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("DELETE FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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
