using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Classes
    {
        #region Properties
        public int ID { get; set; }
        public int Sector { get; set; }
        public int Level { get; set; }
        public int Faculty { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "classes"; } }
        #endregion

        public Classes()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exists()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.sector_id = @sector AND {0}.level_id = @level AND {0}.faculty_id = @faculty", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@sector", Level);
                cmd.Parameters.AddWithValue("@level", Sector);
                cmd.Parameters.AddWithValue("@faculty", Faculty);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@sector, @level, @faculty)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@sector", Sector);
                cmd.Parameters.AddWithValue("@level", Level);
                cmd.Parameters.AddWithValue("@faculty", Faculty);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public Classes Read(int id)
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
                    Sector = sdr.GetInt32(1);
                    Level = sdr.GetInt32(2);
                    Faculty = sdr.GetInt32(3);

                    return this;
                }

                return null;
            }
        }

        public List<Classes> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Classes> classes = new List<Classes>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        classes.Add(new Classes()
                        {
                            ID = sdr.GetInt32(0),
                            Sector = sdr.GetInt32(1),
                            Level = sdr.GetInt32(2),
                            Faculty=sdr.GetInt32(3)
                        });
                    }
                }

                return classes;
            }
        }

        public bool Update(Classes clas)
        {
            using (Connection)
            {
                string strSql = string.Format("UPDATE {0} SET {0}.sector_id = @sector, {0}.level_id = @level, {0}.faculty_id = @faculty WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", clas.ID);
                cmd.Parameters.AddWithValue("@sector", clas.Sector);
                cmd.Parameters.AddWithValue("@level", clas.Level);
                cmd.Parameters.AddWithValue("@faculty", clas.Faculty);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
