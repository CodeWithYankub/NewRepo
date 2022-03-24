using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Form
    {
        #region Properties
        public int ID { get; set; }
        public int Class { get; set; }
        public string Name { get; set; }
        private SqlConnection Connection { get; set; }
        private string Table { get { return "forms"; } }


        #endregion

        public Form()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }
        public bool Exists()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name = @name AND {0}.class_id = @class", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@class", Class);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }
        
        public bool Exists(string key)
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name = @key OR {0}.class_id = @key", Table);
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
                string strSql = string.Format("INSERT INTO {0} VALUES(@class, @name)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@class", Class);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Form Read(int id)
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
                    Class = sdr.GetInt32(1);
                    Name = sdr.GetString(2);

                    return this;
                }

                return null;
            }
        }

        public List<Form> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Form> forms = new List<Form>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        forms.Add(new Form()
                        {
                            ID = sdr.GetInt32(0),
                            Class = sdr.GetInt32(1),
                            Name = sdr.GetString(2)
                        });
                    }
                }

                return forms;
            }
        }

        public List<Form> Search(string key = null)
        {
            key = string.IsNullOrEmpty(key) ? Name : key;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name LIKE @key OR {0}.code LIKE @key", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@key", string.Format("%{0}%", key));

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                List<Form> forms = new List<Form>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        forms.Add(new Form()
                        {
                            ID = sdr.GetInt32(0),
                            Class = sdr.GetInt32(1),
                            Name = sdr.GetString(2)

                        });
                    }
                }

                return forms;
            }
        }

        public bool Update(Form form)
        {
            using (Connection)
            {
                string strSql = string.Format("UPDATE {0} SET {0}.name = @name, {0}.class_id = @class WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", form.ID);
                cmd.Parameters.AddWithValue("@name", form.Name);
                cmd.Parameters.AddWithValue("@class", form.Class);

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
