using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Sub
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        private SqlConnection Connection { get; set; }
        private string Table { get { return "subjects"; } }


        #endregion

        public Sub()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }
        public bool Exists()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name = @name AND {0}.code = @code", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@code", Code);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }
        
        public bool Exists(string key)
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name = @key OR {0}.code = @key", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@key", key);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@name, @code)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@code", Code);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Sub Read(int id)
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", id);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();
                    ID = sdr.GetInt32(0);
                    Name = sdr.GetString(1);
                    Code = sdr.GetString(2);

                    return this;
                }

                return null;
            }
        }

        public List<Sub> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Sub> subjects = new List<Sub>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        subjects.Add(new Sub()
                        {
                            Name = sdr.GetString(1),
                            Code = sdr.GetString(2),
                            ID = sdr.GetInt32(0)

                        });
                    }
                }

                return subjects;
            }
        }

        public List<Sub> Search(string key = null)
        {
            key = string.IsNullOrEmpty(key) ? Name : key;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name LIKE @key OR {0}.code LIKE @key", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@key", string.Format("%{0}%", key));

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                List<Sub> subjects = new List<Sub>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        subjects.Add(new Sub()
                        {
                            Name = sdr.GetString(1),
                            Code = sdr.GetString(2),
                            ID = sdr.GetInt32(0)

                        });
                    }
                }

                return subjects;
            }
        }

        public bool Update(Sub subject)
        {
            using (Connection)
            {
                string strSql = string.Format("UPDATE {0} SET {0}.name = @name, {0}.code = @code WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", subject.ID);
                cmd.Parameters.AddWithValue("@name", subject.Name);
                cmd.Parameters.AddWithValue("@code", subject.Code);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id = 0)
        {
            id = id > 0 ? id : ID;

            using (Connection)
            {
                string strSql = string.Format("DELETE FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", id);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
