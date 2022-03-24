using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Faculty
    {
        #region Properties
        public int ID { get; set; }
        public int SectorId { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Faculties"; } }
        #endregion

        public Faculty()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Name=@name", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@sector", SectorId);
                    cmd.Parameters.AddWithValue("@name", Name);

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
                string query = string.Format("INSERT INTO {0} VALUES(@sector, @name, @acronym)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@sector", SectorId);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@acronym", Acronym);
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
        public List<Faculty> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Faculty> faculties = new List<Faculty>();
                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            faculties.Add(new Faculty()
                            {
                                ID = sdr.GetInt32(0),
                                SectorId = sdr.GetInt32(1),
                                Name = sdr.GetString(2),
                                Acronym = sdr.GetString(3),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return faculties;
            }
        }

        // Fetch a specified record
        public Faculty Read(int id)
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

                        return new Faculty()
                        {
                            ID = sdr.GetInt32(0),
                            SectorId = sdr.GetInt32(1),
                            Name = sdr.GetString(2),
                            Acronym = sdr.GetString(3),
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
                string query = string.Format("UPDATE {0} SET SectorId=@sector, Name=@name, Acronym=@acronym WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sector", SectorId);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@acronym", Acronym);
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
