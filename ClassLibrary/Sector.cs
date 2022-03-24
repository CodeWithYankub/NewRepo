using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Sector
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Sectors"; } }
        #endregion

        public Sector()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists(string name = null)
        {
            name = string.IsNullOrEmpty(name) ? Name : name;

            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Name=@name", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    Connection.Open();
                    
                    return cmd.ExecuteReader().HasRows;
                }catch(Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }
        
        // Create a new record
        public bool Create()
        {
            using(Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("INSERT INTO {0} VALUES(@name, @acronym)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@acronym", Acronym);
                    }

                    Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }catch(Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }
    
        // Fetch all records
        public List<Sector> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        List<Sector> sectors = new List<Sector>();

                        while (sdr.Read())
                        {
                            sectors.Add(new Sector()
                            {
                                ID = sdr.GetInt32(0),
                                Name = sdr.GetString(1),
                                Acronym = sdr.GetString(2),
                            });
                        }

                        return sectors;
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return null;
            }
        }

        // Fetch a specified record
        public Sector Read(int id)
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

                        return new Sector()
                        {
                            ID = sdr.GetInt32(0),
                            Name = sdr.GetString(1),
                            Acronym = sdr.GetString(2),
                        };
                    }
                }catch(Exception ex)
                {
                    App.Error = ex.Message;
                }

                return null;
            }
        }

        // Update a specified record
        public bool Update(int id)
        {
            using (Connection=new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("UPDATE {0} SET Name=@name, Acronym=@acronym WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@acronym", Acronym);
                    }

                    Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }catch(Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }
    }
}
