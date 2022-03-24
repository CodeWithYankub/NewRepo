using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SLMB_SMS.Models
    {
        class FacultyAllocation
        {
            #region Properties
            public int ID { get; set; }
            public int Faculty { get; set; }
            public int Subject { get; set; }
            public bool Core { get; set; }

            private SqlConnection Connection { get; set; }
            private string Table { get { return "subjects_faculties"; } }
            #endregion

            public FacultyAllocation()
            {
                Connection = new SqlConnection(Helper.ConnectionString);
            }

            public bool Create()
            {
                using (Connection = new SqlConnection(Helper.ConnectionString))
                {
                    string strSql = string.Format("INSERT INTO {0} VALUES(@faculty, @subject, @core)", Table);
                    SqlCommand cmd = new SqlCommand(strSql, Connection);
                    cmd.Parameters.AddWithValue("@faculty", Faculty);
                    cmd.Parameters.AddWithValue("@subject", Subject);
                    cmd.Parameters.AddWithValue("@core", Core);

                    Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }

            public List<FacultyAllocation> Read(int faculty = 0)
            {
                using (Connection)
                {
                    string strSql = string.Format("SELECT * FROM {0}{1}", Table, faculty > 0 ? " WHERE {0}.faculty = @faculty" : "");

                    SqlCommand cmd = new SqlCommand(strSql, Connection);
                    if (faculty > 0)
                        cmd.Parameters.AddWithValue("@faculty", faculty);

                    Connection.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    List<FacultyAllocation> facultyAllocations = new List<FacultyAllocation>();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            facultyAllocations.Add(new FacultyAllocation()
                            {
                                ID = sdr.GetInt32(0),
                                Faculty = sdr.GetInt32(1),
                                Subject = sdr.GetInt32(2),
                                Core = sdr.GetInt32(3) > 0
                            });
                        }
                    }

                    return facultyAllocations;
                }
            }

            public bool Update(FacultyAllocation facultyAllocation)
            {
                using (Connection)
                {
                    string strSql = string.Format("UPDATE {0} SET {0}.faculty = @faculty, 0}.subject = @subject, {0}.core = @core", Table);

                    SqlCommand cmd = new SqlCommand(strSql, Connection);
                    cmd.Parameters.AddWithValue("@faculty", facultyAllocation.Faculty);
                    cmd.Parameters.AddWithValue("@subject", facultyAllocation.Subject);
                    cmd.Parameters.AddWithValue("@core", facultyAllocation.Core);

                    Connection.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }

}
