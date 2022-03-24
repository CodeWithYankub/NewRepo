using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class StudentSubject
    {
        #region Properties
        public int ID { get; set; }
        public int RegistrationId { get; set; }
        public int SubjectId { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "StudentSubjects"; } }
        #endregion

        public StudentSubject()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE RegistrationId=@registration AND SubjectId=@subject", Table);

                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    cmd.Parameters.AddWithValue("@registration", RegistrationId);
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
                string query = string.Format("INSERT INTO {0} VALUES(@registration, @subject)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@registration", RegistrationId);
                        cmd.Parameters.AddWithValue("@subject", SubjectId);
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
        public List<StudentSubject> Read(int registrationId=0)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE RegistrationId=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<StudentSubject> registrationSubjects = new List<StudentSubject>();

                try
                {
                    cmd.Parameters.AddWithValue("@id", registrationId);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            registrationSubjects.Add(new StudentSubject()
                            {
                                ID = sdr.GetInt32(0),
                                RegistrationId = sdr.GetInt32(1),
                                SubjectId = sdr.GetInt32(2)
                            });
                        }

                        return registrationSubjects;
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return registrationSubjects;
            }
        }

        // Update a specified record
        public bool Update(int id)
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("UPDATE {0} SET RegistrationId=@registration, SubjectId=@subject, YearId=@year, Core=@core WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@registration", RegistrationId);
                        cmd.Parameters.AddWithValue("@subject", SubjectId);
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
