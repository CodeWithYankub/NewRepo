using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Grade
    {
        #region Properties
        public int ID { get; set; }
        public int RegistrationId { get; set; }
        public int Term { get; set; }
        public int Exam { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime EnteredOn { get; set; }
        public int EnteredBy { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "Grades"; } }
        #endregion

        public Grade()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE RegistrationId=@reg AND YearId=@year AND Term=@term AND Exam=@exam", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@reg", RegistrationId);
                    cmd.Parameters.AddWithValue("@term", Term);
                    cmd.Parameters.AddWithValue("@exam", Exam);

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
                string query = string.Format("INSERT INTO {0} VALUES(@reg, @term, @exam, @updatedon, @updatedby, @enteredon, @enteredby); SELECT SCOPE_IDENTITY()", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@reg", RegistrationId);
                        cmd.Parameters.AddWithValue("@term", Term);
                        cmd.Parameters.AddWithValue("@exam", Exam);
                        cmd.Parameters.AddWithValue("@updatedon", DateTime.Now);
                        cmd.Parameters.AddWithValue("@updatedby", App.Logged.ID);
                        cmd.Parameters.AddWithValue("@enteredon", DateTime.Now);
                        cmd.Parameters.AddWithValue("@enteredby", App.Logged.ID);
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
        public List<Grade> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Grade> grades = new List<Grade>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            grades.Add(new Grade()
                            {
                                ID = sdr.GetInt32(0),
                                RegistrationId = sdr.GetInt32(1),
                                Term = sdr.GetInt32(2),
                                Exam = sdr.GetInt32(3),
                                UpdatedOn = sdr.GetDateTime(4),
                                UpdatedBy = sdr.GetInt32(5),
                                EnteredOn = sdr.GetDateTime(6),
                                EnteredBy = sdr.GetInt32(7),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return grades;
            }
        }

        // Fetch a specified record
        public Grade Read(int id)
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

                        return new Grade()
                        {
                            ID = sdr.GetInt32(0),
                            RegistrationId = sdr.GetInt32(1),
                            Term = sdr.GetInt32(2),
                            Exam = sdr.GetInt32(3),
                            UpdatedOn = sdr.GetDateTime(4),
                            UpdatedBy = sdr.GetInt32(5),
                            EnteredOn = sdr.GetDateTime(6),
                            EnteredBy = sdr.GetInt32(7),
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
                string query = string.Format("UPDATE {0} SET RegistrationId=@reg, Term=@term, Exam=@exam, UpdatedOn=@updatedon, UpdatedBy=@updatedby WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@reg", RegistrationId);
                        cmd.Parameters.AddWithValue("@term", Term);
                        cmd.Parameters.AddWithValue("@exam", Exam);
                        cmd.Parameters.AddWithValue("@updatedon", DateTime.Now);
                        cmd.Parameters.AddWithValue("@updatedby", App.Logged.ID);
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

        // Update a specified record
        public bool Delete(int id)
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("DELETE FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@id", id);
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
