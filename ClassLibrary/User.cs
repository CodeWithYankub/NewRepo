using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class User
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public App.Gender Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public App.UserType UserType { get; set; }
        public bool Active { get; set; }
        public DateTime DateRegistered { get; set; }

        private string Table { get { return "Users"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public User()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists(string uid = null)
        {
            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Email=@email OR Username=@username OR Phone=@phone", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    var got = !string.IsNullOrEmpty(uid);

                    /* populate parameters */
                    {
                        cmd.Parameters.AddWithValue("@email", got ? uid : Email);
                        cmd.Parameters.AddWithValue("@username", got ? uid : Username);
                        cmd.Parameters.AddWithValue("@phone", got ? uid : Phone);
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
                string query = string.Format("INSERT INTO {0} VALUES(@name, @gender, @address, @phone, @email, @photo, @username, @password, @usertype, @active, @dateregistered)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@gender", Gender);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@photo", Photo);
                        cmd.Parameters.AddWithValue("@username", Username);
                        cmd.Parameters.AddWithValue("@password", App.PasswordHash(Password));
                        cmd.Parameters.AddWithValue("@usertype", UserType);
                        cmd.Parameters.AddWithValue("@active", Active);
                        cmd.Parameters.AddWithValue("@dateregistered", DateTime.Now);
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
        public List<User> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<User> users = new List<User>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            users.Add(new User()
                            {
                                ID = sdr.GetInt32(0),
                                Name = sdr.GetString(1),
                                Gender = (App.Gender)sdr.GetInt32(2),
                                Address= sdr.GetString(3),
                                Phone= sdr.GetString(4),
                                Email= sdr.GetString(5),
                                Photo= sdr.GetString(6),
                                Username= sdr.GetString(7),
                                Password= sdr.GetString(8),
                                UserType= (App.UserType)sdr.GetInt32(9),
                                Active= sdr.GetBoolean(10),
                                DateRegistered= sdr.GetDateTime(11),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return users;
            }
        }

        // Login a specified record
        public User Login(string username)
        {
            using (Connection)
            {
                string query = string.Format("SELECT {0}.Id FROM {0} WHERE Username=@uname", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@uname", username);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        int id = sdr.GetInt32(0);

                        User user = new User().Read(id);
                        return user;
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return null;
            }
        }

        // Fetch a specified record
        public User Read(int uid)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE Id=@uid", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@uid", uid);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();

                        return new User()
                        {
                            ID = sdr.GetInt32(0),
                            Name = sdr.GetString(1),
                            Gender = (App.Gender)sdr.GetInt32(2),
                            Address = sdr.GetString(3),
                            Phone = sdr.GetString(4),
                            Email = sdr.GetString(5),
                            Photo = sdr.GetString(6),
                            Username = sdr.GetString(7),
                            Password = sdr.GetString(8),
                            UserType = (App.UserType)sdr.GetInt32(9),
                            Active = sdr.GetBoolean(10),
                            DateRegistered = sdr.GetDateTime(11),
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
                string query = string.Format("UPDATE {0} SET Name=@name, Gender=@gender, Address=@address, Phone=@phone, Email=@email, Photo=@photo, Username=@username, Password=@password, UserType=@usertype, Active=@active WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@name", Name);
                        cmd.Parameters.AddWithValue("@gender", Gender);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@photo", Photo);
                        cmd.Parameters.AddWithValue("@username", Username);
                        cmd.Parameters.AddWithValue("@password", Password);
                        cmd.Parameters.AddWithValue("@usertype", UserType);
                        cmd.Parameters.AddWithValue("@active", Active);
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
    }
}
