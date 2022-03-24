using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GradeSubject
    {
        #region Properties
        public int ID { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        public int Score { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "GradeSubjects"; } }
        #endregion

        public GradeSubject()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE GradeId=@grade AND SubjectId=@subject", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@grade", GradeId);
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
                string query = string.Format("INSERT INTO {0} VALUES(@grade, @subject, @score)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@grade", GradeId);
                        cmd.Parameters.AddWithValue("@subject", SubjectId);
                        cmd.Parameters.AddWithValue("@score", Score);
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

        // Fetch all records by grade
        public List<GradeSubject> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<GradeSubject> grades = new List<GradeSubject>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            grades.Add(new GradeSubject()
                            {
                                ID = sdr.GetInt32(0),
                                GradeId = sdr.GetInt32(1),
                                SubjectId = sdr.GetInt32(2),
                                Score = sdr.GetInt32(3)
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

        // Fetch all records by grade
        public List<GradeSubject> Read(Grade grade)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE GradeId=@grade", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<GradeSubject> grades = new List<GradeSubject>();

                try
                {
                    cmd.Parameters.AddWithValue("@grade", grade.ID);
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            grades.Add(new GradeSubject()
                            {
                                ID = sdr.GetInt32(0),
                                GradeId = sdr.GetInt32(1),
                                SubjectId = sdr.GetInt32(2),
                                Score = sdr.GetInt32(3)
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

        // Fetch single records
        public GradeSubject Read(int id)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<GradeSubject> grades = new List<GradeSubject>();

                try
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();

                        return new GradeSubject()
                        {
                            ID = sdr.GetInt32(0),
                            GradeId = sdr.GetInt32(1),
                            SubjectId = sdr.GetInt32(2),
                            Score = sdr.GetInt32(3)
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
                string query = string.Format("UPDATE {0} SET Score=@score WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@score", Score);
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
