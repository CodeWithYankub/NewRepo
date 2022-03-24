using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class DBHelper
    {
        public static bool IsConnected
        {
            get
            {
                using (SqlConnection conn = new SqlConnection(App.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                        return conn.State == System.Data.ConnectionState.Open;
                    }
                    catch (Exception ex)
                    {
                        App.Error = ex.Message;
                        return false;
                    }
                }
            }
        }
        public static bool Exists<T>(string table, string field, T value)
        {
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("SELECT * FROM {0} WHERE {1}=@uid", table, field);
                SqlCommand cmd = new SqlCommand();
                try
                {
                    cmd.Parameters.AddWithValue("@uid", value);

                    conn.Open();

                    return cmd.ExecuteReader().HasRows;
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                    return false;
                }
            }
        }

        public static bool Exists(string table, Dictionary<string, string> data, string delimeter = "AND")
        {
            using (SqlConnection conn = new SqlConnection(App.ConnectionString))
            {
                string fieldValues = string.Empty; int index = 0;

                foreach (var key in data.Keys)
                {
                    fieldValues += string.Format("{0}={1} {3}", key, data[key], index < 1 ? delimeter : "");
                    index += 1;
                }

                string query = string.Format("SELECT * FROM {0} WHERE {1}", table, fieldValues);
                SqlCommand cmd = new SqlCommand();

                try
                {
                    conn.Open();
                    return cmd.ExecuteReader().HasRows;
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
