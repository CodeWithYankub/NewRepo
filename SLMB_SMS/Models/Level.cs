using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Level
    {
        #region Properties
        public int ID { get; set; }
        public int Sector { get; set; }
        public int Class { get; set; }

        private string Table { get { return "levels"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public Level()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exists(int clas = 0, int sector = 0)
        {
            clas = clas > 0 ? clas : Class;
            sector = sector > 0 ? sector : Sector;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.class = @class AND {0}.sector_id = @sec", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@class", clas);
                cmd.Parameters.AddWithValue("@sec", sector);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@sector, @class)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@sector", Sector);
                cmd.Parameters.AddWithValue("@class", Class);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Level Read(int id)
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
                    Class = sdr.GetInt32(2);

                    return this;
                }

                return null;
            }
        }

        public List<Level> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Level> levels = new List<Level>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        levels.Add(new Level()
                        {
                            Sector = sdr.GetInt32(1),
                            Class = sdr.GetInt32(2),
                            ID = sdr.GetInt32(0)

                        });
                    }
                }

                return levels;
            }
        }

        public bool Update(Level level)
        {
            using (Connection)
            {
                string strSql = string.Format("UPDATE {0} SET {0}.sector_id = @sector, {0}.class = @class WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", level.ID);
                cmd.Parameters.AddWithValue("@sector", level.Sector);
                cmd.Parameters.AddWithValue("@class", level.Class);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
