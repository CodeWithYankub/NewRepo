using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Teacher
    {
        #region Properties
        public int ID { get; set; }
        public int SectorId { get; set; }
        public long PinCode { get; set; }
        public string Name { get; set; }
        public App.Gender Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Approved { get; set; }
        public bool Active { get; set; }
        public Kin NextOfKin { get; set; }
        public DateTime EmployedOn { get; set; }
        public DateTime RegisteredOn { get; set; }
        public int RegisteredBy { get; set; }

        private string Table { get { return "Teachers"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public Teacher()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists()
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Pincode=@pincode OR Phone=@phone", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Populate parameters */
                    {
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@pincode", PinCode);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                    }
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
        
        public bool Exists<T>(string key, T value)
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE {1}=@{2}", Table, key,key.ToLower());
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Populate parameters */
                    {
                        cmd.Parameters.AddWithValue(string.Format("@{0}", key.ToLower()), value);
                    }

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
                string query = string.Format("INSERT INTO {0} VALUES(@sector, @pincode, @name, @gender, @email, @address, @phone, @approved, @active, @nkname, @nkemail, @nkaddress, @nkphone, @nkrelationship, @employedon, @registeredon, @registeredby)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@sector", SectorId);
                        cmd.Parameters.AddWithValue("@pincode", PinCode);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@gender", Gender);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@approved", Approved);
                        cmd.Parameters.AddWithValue("@active", Active);
                        cmd.Parameters.AddWithValue("@nkname", NextOfKin.Name);
                        cmd.Parameters.AddWithValue("@nkemail", NextOfKin.Email);
                        cmd.Parameters.AddWithValue("@nkaddress", NextOfKin.Address);
                        cmd.Parameters.AddWithValue("@nkphone", NextOfKin.Phone);
                        cmd.Parameters.AddWithValue("@nkrelationship", NextOfKin.Relationship);
                        cmd.Parameters.AddWithValue("@employedon", EmployedOn);
                        cmd.Parameters.AddWithValue("@registeredon", DateTime.Now);
                        cmd.Parameters.AddWithValue("@registeredby", App.Logged.ID);
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

        // Fetch all records
        public List<Teacher> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Teacher> teachers = new List<Teacher>();
                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Kin kin = new Kin()
                            {
                                Name = sdr.GetString(10),
                                Email = sdr.GetString(11),
                                Address = sdr.GetString(12),
                                Phone = sdr.GetString(13),
                                Relationship = sdr.GetString(14)
                            };
                            teachers.Add(new Teacher()
                            {
                                ID = sdr.GetInt32(0),
                                SectorId= sdr.GetInt32(1),
                                PinCode = sdr.GetInt64(2),
                                Name = sdr.GetString(3),
                                Gender = (App.Gender)sdr.GetInt32(4),
                                Email = sdr.GetString(5),
                                Address = sdr.GetString(6),
                                Phone = sdr.GetString(7),
                                Approved = sdr.GetBoolean(8),
                                Active = sdr.GetBoolean(9),
                                NextOfKin = kin,
                                EmployedOn = sdr.GetDateTime(15),
                                RegisteredOn = sdr.GetDateTime(16),
                                RegisteredBy = sdr.GetInt32(17)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return teachers;
            }
        }

        // Fetch a specified record
        public Teacher Read(int id)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE Id=@uid", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@uid", id);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();

                        Kin kin = new Kin()
                        {
                            Name = sdr.GetString(10),
                            Email = sdr.GetString(11),
                            Address = sdr.GetString(12),
                            Phone = sdr.GetString(13),
                            Relationship = sdr.GetString(14)
                        };

                        return new Teacher()
                        {
                            ID = sdr.GetInt32(0),
                            SectorId = sdr.GetInt32(1),
                            PinCode = sdr.GetInt64(2),
                            Name = sdr.GetString(3),
                            Gender = (App.Gender)sdr.GetInt32(4),
                            Email = sdr.GetString(5),
                            Address = sdr.GetString(6),
                            Phone = sdr.GetString(7),
                            Approved = sdr.GetBoolean(8),
                            Active = sdr.GetBoolean(9),
                            NextOfKin = kin,
                            EmployedOn = sdr.GetDateTime(15),
                            RegisteredOn = sdr.GetDateTime(16),
                            RegisteredBy = sdr.GetInt32(17)
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
                string query = string.Format("UPDATE {0} SET SectorId=@sector, PinCode=@pincode, Name=@name, Gender=@gender, Email=@email, Address=@address, Phone=@phone, Approved=@approved, Active=@active, NKName=@nkname, NKEmail=@nkemail, NKAddress=@nkaddress, NKPhone=@nkphone, Relationship=@nkrelationship, EmployedOn=@employedon WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@sector", SectorId);
                        cmd.Parameters.AddWithValue("@pincode", PinCode);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@gender", Gender);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@approved", Approved);
                        cmd.Parameters.AddWithValue("@active", Active);
                        cmd.Parameters.AddWithValue("@nkname", NextOfKin.Name);
                        cmd.Parameters.AddWithValue("@nkemail", NextOfKin.Email);
                        cmd.Parameters.AddWithValue("@nkaddress", NextOfKin.Address);
                        cmd.Parameters.AddWithValue("@nkphone", NextOfKin.Phone);
                        cmd.Parameters.AddWithValue("@nkrelationship", NextOfKin.Relationship);
                        cmd.Parameters.AddWithValue("@employedon", EmployedOn);
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

        public bool Delete()
        {
            using (Connection = new SqlConnection(App.ConnectionString))
            {
                string query = string.Format("UPDATE {0} SET Active=@active WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@active", !Active);

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
        public class Kin
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Relationship { get; set; }
        }
    }
}
