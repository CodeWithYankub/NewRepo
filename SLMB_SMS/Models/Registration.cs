using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Registration
    {
        #region Properties
        public int ID { get; set; }
        public int Student { get; set; }
        public int Year { get; set; }
        public int Form { get; set; }
        public int Receipt { get; set; } 
        public DateTime DateRegisterd { get; set; }
        private string Table { get { return "registrations"; } }
        private SqlConnection Connection { get; set; }


        #endregion

        public Registration()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }
        public bool Exists(int student = 0, int year=0)
        {
            student = student > 0 ? student : Student;
            year = year > 0 ? year : Year;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.student_id = @student AND {0}.year_id = @year", Table);

                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@student", student);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }
        
        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@student, @year, @form, @receipt, @date)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@student", Student);
                cmd.Parameters.AddWithValue("@year", Year);
                cmd.Parameters.AddWithValue("@form", Form);
                cmd.Parameters.AddWithValue("@receipt", Receipt);
                cmd.Parameters.AddWithValue("@date", DateRegisterd);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Registration Read(int id)
        {
            using (Connection)
            {
                string strSql = string.Format
                    ("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", id);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    ID = sdr.GetInt32(0);
                    Student = sdr.GetInt32(1);
                    Year = sdr.GetInt32(2);
                    Form = sdr.GetInt32(3);
                    Receipt = sdr.GetInt32(4);
                    DateRegisterd = sdr.GetDateTime(5);

                    return this;
                }

                return null;
            }
        }

        public List<Registration> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Registration> reg = new List<Registration>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        reg.Add(new Registration()
                        {
                            ID = sdr.GetInt32(0),
                            Student = sdr.GetInt32(1),
                            Year = sdr.GetInt32(2),
                            Form = sdr.GetInt32(3),
                            Receipt= sdr.GetInt32(4),
                            DateRegisterd = sdr.GetDateTime(5)
                        });
                    }
                }

                return reg;
            }
        }

        public bool Update(Registration registration)
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("UPDATE {0} SET {0}.form_id = @form WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);

                /* Define paramaeters */
                {
                    cmd.Parameters.AddWithValue("@id", registration.ID);
                    cmd.Parameters.AddWithValue("@form", registration.Form);

                }

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;

            }
        }
        public List<Registration> Search(string key = null)
        {
            key = string.IsNullOrEmpty(key) ? Student.ToString() : key;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.student_id LIKE @key OR {0}.receipt LIKE @key", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@key", string.Format("%{0}%", key));

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                List<Registration> reg = new List<Registration>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        reg.Add(new Registration()
                        {
                            ID = sdr.GetInt32(0),
                            Student = sdr.GetInt32(1),
                            Year = sdr.GetInt32(2),
                            Form = sdr.GetInt32(3),
                            Receipt = sdr.GetInt32(4),
                            DateRegisterd = sdr.GetDateTime(5)
                        });
                    }
                }

                return reg;
            }

        
        }

    }
}

