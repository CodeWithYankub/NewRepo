using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Student
    {
        #region Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public App.Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public bool Active { get; set; }
        public App.Color Color { get; set; }
        public Parent ParentDetails { get; set; }
        public DateTime AdmittedOn { get; set; }
        public int YearId { get; set; }
        public int AdmittedBy { get; set; }
        public string Result { get; set; }

        private string Table { get { return "Students"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public Student()
        {
            Connection = new SqlConnection(App.ConnectionString);
        }

        // Check if exists
        public bool Exists(int id = 0)
        {
            id = id < 1 ? ID : id;

            using (Connection)
            {
                string query = string.Format("SELECT Id FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Populate parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
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
                string query = string.Format("INSERT INTO {0} VALUES(@fname, @oname, @lname, @gender, @dob, @email, @address, @phone, @photo, @active, @color, @pname, @poccupation, @pemail, @paddress, @pphone, @relationship, @admittedon, @yearid, @admittedby, @result)", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                try
                {
                    /* Add parameters */
                    {
                       // cmd.Parameters.AddWithValue("@id", ID);
                        cmd.Parameters.AddWithValue("@fname", FirstName);
                        cmd.Parameters.AddWithValue("@oname", OtherName);
                        cmd.Parameters.AddWithValue("@lname", LastName);
                        cmd.Parameters.AddWithValue("@gender", Gender);
                        cmd.Parameters.AddWithValue("@dob", DateOfBirth);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@photo", Photo);
                        cmd.Parameters.AddWithValue("@active", Active);
                        cmd.Parameters.AddWithValue("@color", Color);
                        cmd.Parameters.AddWithValue("@pname", ParentDetails.Name);
                        cmd.Parameters.AddWithValue("@poccupation", ParentDetails.Occupation);
                        cmd.Parameters.AddWithValue("@pemail", ParentDetails.Email);
                        cmd.Parameters.AddWithValue("@paddress", ParentDetails.Address);
                        cmd.Parameters.AddWithValue("@pphone", ParentDetails.Phone);
                        cmd.Parameters.AddWithValue("@relationship", ParentDetails.Relationship);
                        cmd.Parameters.AddWithValue("@admittedon", AdmittedOn);
                        cmd.Parameters.AddWithValue("@yearid", YearId);
                        cmd.Parameters.AddWithValue("@admittedby", AdmittedBy);
                        cmd.Parameters.AddWithValue("@result", Result);
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
        public List<Student> Read()
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);

                List<Student> students = new List<Student>();

                try
                {
                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Parent parent = new Parent()
                            {
                                Name = sdr.GetString(12),
                                Occupation = sdr.GetString(13),
                                Email = sdr.GetString(14),
                                Address = sdr.GetString(15),
                                Phone = sdr.GetString(16),
                                Relationship = sdr.GetString(17),
                            };
                            students.Add(new Student()
                            {
                                ID = sdr.GetInt32(0),
                                FirstName = sdr.GetString(1),
                                OtherName = sdr.GetString(2),
                                LastName = sdr.GetString(3),
                                Gender = (App.Gender)sdr.GetInt32(4),
                                DateOfBirth = sdr.GetDateTime(5),
                                Email = sdr.GetString(6),
                                Address = sdr.GetString(7),
                                Phone = sdr.GetString(8),
                                Photo = sdr.GetString(9),
                                Active = sdr.GetBoolean(10),
                                Color = (App.Color)sdr.GetInt32(11),
                                ParentDetails = parent,
                                AdmittedOn = sdr.GetDateTime(18),
                                YearId = sdr.GetInt32(19),
                                AdmittedBy = sdr.GetInt32(20),
                                Result = sdr.GetString(21),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    App.Error = ex.Message;
                }

                return students;
            }
        }

        // Fetch a specified record
        public Student Read(int id)
        {
            using (Connection)
            {
                string query = string.Format("SELECT * FROM {0} WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    Connection.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        sdr.Read();

                        Parent parent = new Parent()
                        {
                            Name = sdr.GetString(12),
                            Occupation = sdr.GetString(13),
                            Email = sdr.GetString(14),
                            Address = sdr.GetString(15),
                            Phone = sdr.GetString(16),
                            Relationship = sdr.GetString(17),
                        };

                        return new Student()
                        {
                            ID = sdr.GetInt32(0),
                            FirstName = sdr.GetString(1),
                            OtherName = sdr.GetString(2),
                            LastName = sdr.GetString(3),
                            Gender = (App.Gender)sdr.GetInt32(4),
                            DateOfBirth = sdr.GetDateTime(5),
                            Email = sdr.GetString(6),
                            Address = sdr.GetString(7),
                            Phone = sdr.GetString(8),
                            Photo = sdr.GetString(9),
                            Active = sdr.GetBoolean(10),
                            Color = (App.Color)sdr.GetInt32(11),
                            ParentDetails = parent,
                            AdmittedOn = sdr.GetDateTime(18),
                            YearId = sdr.GetInt32(19),
                            AdmittedBy = sdr.GetInt32(20),
                            Result = sdr.GetString(21),
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
                string query = string.Format("UPDATE {0} SET FName=@fname, OName=@oname, LName=@lname, Gender=@gender, DOB=@dob, Email=@email, Address=@address, Phone=@phone, Photo=@photo, Active=@active, Color=@color, PName=@pname, POccupation=@poccupation, PEmail=@pemail, PAddress=@paddress, PPhone=@pphone, Relationship=@relationship, YearId=@yearid, Result=@result WHERE Id=@id", Table);
                SqlCommand cmd = new SqlCommand(query, Connection);
                try
                {
                    /* Add parameters */
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@fname", FirstName);
                        cmd.Parameters.AddWithValue("@oname", OtherName);
                        cmd.Parameters.AddWithValue("@lname", LastName);
                        cmd.Parameters.AddWithValue("@gender", Gender);
                        cmd.Parameters.AddWithValue("@dob", DateOfBirth);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@address", Address);
                        cmd.Parameters.AddWithValue("@phone", Phone);
                        cmd.Parameters.AddWithValue("@photo", Photo);
                        cmd.Parameters.AddWithValue("@active", Active);
                        cmd.Parameters.AddWithValue("@color", Color);
                        cmd.Parameters.AddWithValue("@pname", ParentDetails.Name);
                        cmd.Parameters.AddWithValue("@poccupation", ParentDetails.Occupation);
                        cmd.Parameters.AddWithValue("@pemail", ParentDetails.Email);
                        cmd.Parameters.AddWithValue("@paddress", ParentDetails.Address);
                        cmd.Parameters.AddWithValue("@pphone", ParentDetails.Phone);
                        cmd.Parameters.AddWithValue("@relationship", ParentDetails.Relationship);
                        cmd.Parameters.AddWithValue("@yearid", YearId);
                        cmd.Parameters.AddWithValue("@result", Result);
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

        // Internal Parent Class
        public class Parent
        {
            public string Name { get; set; }
            public string Occupation { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Relationship { get; set; }
        }
    }
}
