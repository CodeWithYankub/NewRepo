using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Level
    {
        #region Properties
        public int ID { get; set; }
        public int SectorId { get; set; }
        public int Class { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Levels"; } }
        #endregion

        public Level()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE SectorId=@sector AND Class=@class", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@sector", SectorId);
                    cmd.Parameters.AddWithValue("@class", Class);

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
                string query = string.Format("INSERT INTO {0} VALUES(@sector, @class)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@sector", SectorId);
                        cmd.Parameters.AddWithValue("@class", Class);
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
        public List<Level> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Level> levels = new List<Level>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            levels.Add(new Level()
                            {
                                ID = sdr.GetInt32(0),
                                SectorId = sdr.GetInt32(1),
                                Class = sdr.GetInt32(2),
                            });
                        }

                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return levels;
            }
        }

        // Fetch a specified record
        public Level Read(int id)
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

                        return new Level()
                        {
                            ID = sdr.GetInt32(0),
                            SectorId = sdr.GetInt32(1),
                            Class = sdr.GetInt32(2),
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
                string query = string.Format("UPDATE {0} SET SectorId=@sector, Class=@class WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sector", SectorId);
                        cmd.Parameters.AddWithValue("@class", Class);
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
