using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class FacultySubject
    {
        #region Properties
        public int ID { get; set; }
        public int FacultyId { get; set; }
        public int SubjectId { get; set; }
        public bool Core { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "FacultySubjects"; } }
        #endregion

        public FacultySubject()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE FacultyId=@faculty AND SubjectId=@subject", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@faculty", FacultyId);
                    cmd.Parameters.AddWithValue("@subject", SubjectId);

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
                string query = string.Format("INSERT INTO {0} VALUES(@faculty, @subject, @core)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@faculty", FacultyId);
                        cmd.Parameters.AddWithValue("@subject", SubjectId);
                        cmd.Parameters.AddWithValue("@core", Core);
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
        public List<FacultySubject> Read(int facultyId)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE FacultyId=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<FacultySubject> facultySubjects = new List<FacultySubject>();

                try
                {
                    cmd.Parameters.AddWithValue("@id", facultyId);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            facultySubjects.Add(new FacultySubject()
                            {
                                ID = sdr.GetInt32(0),
                                FacultyId = sdr.GetInt32(1),
                                SubjectId = sdr.GetInt32(2),
                                Core = sdr.GetBoolean(3),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return facultySubjects;
            }
        }

        // Get a specified record
        // Fetch all records
        public FacultySubject Get(int id)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<FacultySubject> facultySubjects = new List<FacultySubject>();

                try
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        return new FacultySubject()
                        {
                            ID = sdr.GetInt32(0),
                            FacultyId = sdr.GetInt32(1),
                            SubjectId = sdr.GetInt32(2),
                            Core = sdr.GetBoolean(3),
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
                string query = string.Format("UPDATE {0} SET FacultyId=@faculty, SubjectId=@subject, Core=@core WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@faculty", FacultyId);
                        cmd.Parameters.AddWithValue("@subject", SubjectId);
                        cmd.Parameters.AddWithValue("@core", Core);
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
