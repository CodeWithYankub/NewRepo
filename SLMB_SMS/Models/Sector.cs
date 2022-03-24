using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Sector
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }

        // connection
        private SqlConnection Connection{get; set;}

        // define model table
        private string Table { get { return "sectors"; } }
        #endregion

        public Sector()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exists(string name = null)
        {
            name = !string.IsNullOrEmpty(name) ? name : Name;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.name=@name", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@name", name);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@name, @acronym)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@acronym", Acronym.ToUpper());

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Sector Read(int id)
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
                    Acronym = sdr.GetString(2);

                    return this;
                }

                return null;
            }
        }

        public List<Sector> Read()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Sector> sectors = new List<Sector>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        sectors.Add(new Sector()
                        {
                            Name = sdr.GetString(1),
                            Acronym = sdr.GetString(2),
                            ID = sdr.GetInt32(0)

                        });
                    }
                }

                return sectors;
            }
        }

        public bool Update(Sector sector)
        {
            using (Connection)
            {
                string strSql = string.Format("UPDATE {0} SET {0}.name = @name, {0}.acronym = @acronym WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@id", sector.ID);
                cmd.Parameters.AddWithValue("@name", sector.Name);
                cmd.Parameters.AddWithValue("@acronym", sector.Acronym);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
