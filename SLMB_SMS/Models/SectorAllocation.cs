using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class SectorAllocation
    {
        #region Properties
        public int ID { get; set; }
        public int Sector { get; set; }
        public int Subject { get; set; }
        public bool Core { get; set; }

        private SqlConnection Connection { get; set; }
        private string Table { get { return "subjects_sectors"; } }
        #endregion

        public SectorAllocation()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exist()
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.sector = @sector AND {0}.subject = @subject", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@sector", Sector);
                cmd.Parameters.AddWithValue("@subject", Subject);

                Connection.Open();

                return cmd.ExecuteReader().HasRows;
            }
        }

        public bool Create()
        {
            using(Connection = new SqlConnection(Helper.ConnectionString))
            {
                string strSql = string.Format("INSERT INTO {0} VALUES(@sector, @subject, @core)", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@sector", Sector);
                cmd.Parameters.AddWithValue("@subject", Subject);
                cmd.Parameters.AddWithValue("@core", Core);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<SectorAllocation> Read(int sector = 0)
        {
            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {1}{0}", sector > 0 ? " WHERE sector = @sector" : "", Table);

                SqlCommand cmd = new SqlCommand(strSql, Connection);
                if (sector > 0)
                    cmd.Parameters.AddWithValue("@sector", sector);

                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<SectorAllocation> sectorAllocations = new List<SectorAllocation>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        sectorAllocations.Add(new SectorAllocation()
                        {
                            ID = sdr.GetInt32(0),
                            Sector = sdr.GetInt32(1),
                            Subject = sdr.GetInt32(2),
                            Core = sdr.GetInt32(3) > 0
                        });
                    }
                }

                return sectorAllocations;
            }
        }

        public bool Update(SectorAllocation sectorAllocation)
        {
            using (Connection)
            {
                string strSql = string.Format("UPDATE {0} SET {0}.sector = @sector, {0}.subject = @subject, {0}.is_compulsory = @core WHERE {0}.id = @id", Table);

                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@sector", sectorAllocation.Sector);
                cmd.Parameters.AddWithValue("@subject", sectorAllocation.Subject);
                cmd.Parameters.AddWithValue("@core", sectorAllocation.Core);
                cmd.Parameters.AddWithValue("@id", sectorAllocation.ID);

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        
        public bool Delete(int id)
        {
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
