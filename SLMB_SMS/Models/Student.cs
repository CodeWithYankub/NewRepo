using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Student
    {
        #region Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public Helper.Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Image { get; set; }
        public string ParentName { get; set; }
        public string ParentOccuption { get; set; }
        public string ParentRelationShip { get; set; }
        public string ParentPhone { get; set; }
        public string ParentAddress { get; set; }
        public string ParentEmail { get; set; }
        public bool IsActive { get; set; }
        public Helper.Colour Color { get; set; }
        public DateTime AddmisionDate { get; set; }

        private string Table { get { return "students"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public Student()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }

        public bool Exists(int id = 0)
        {
            id = id.Equals(0) ? ID : id;

            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@id", id);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("INSERT INTO {0} VALUES(@id, @fname, @lname, @oname, @gender, @dob, @email, @adres, @phone, @img, @pname, @occu, @relation, @pphone, @padres, @pemail, @active, @color, @admitted)", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);

                /* Define paramaeters */
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@fname", FirstName);
                    cmd.Parameters.AddWithValue("@lname", LastName);
                    cmd.Parameters.AddWithValue("@oname", OtherName);
                    cmd.Parameters.AddWithValue("@gender", Gender);
                    cmd.Parameters.AddWithValue("@dob", DateOfBirth);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@adres", Address);
                    cmd.Parameters.AddWithValue("@phone", PhoneNo);
                    cmd.Parameters.AddWithValue("@pname", ParentName);
                    cmd.Parameters.AddWithValue("@occu", ParentOccuption);
                    cmd.Parameters.AddWithValue("@relation", ParentRelationShip);
                    cmd.Parameters.AddWithValue("@pphone", ParentPhone);
                    cmd.Parameters.AddWithValue("@padres", ParentAddress);
                    cmd.Parameters.AddWithValue("@pemail", ParentEmail);
                    cmd.Parameters.AddWithValue("@active", IsActive);
                    cmd.Parameters.AddWithValue("@color", Color);
                    cmd.Parameters.AddWithValue("@admitted", AddmisionDate);
                    cmd.Parameters.AddWithValue("@img", Helper.Upload(ID, Image));
                }

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Student Read(int id)
        {
            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@id", id);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    sdr.Read();

                    return new Student()
                    {
                        ID = sdr.GetInt32(0),
                        FirstName = sdr.GetString(1),
                        LastName = sdr.GetString(2),
                        OtherName = sdr.GetString(3),
                        Gender = (Helper.Gender)sdr.GetInt32(4),
                        DateOfBirth = sdr.GetDateTime(5),
                        Email = sdr.GetString(6),
                        Address = sdr.GetString(7),
                        PhoneNo = sdr.GetString(8),
                        Image = string.Format(@"{0}\{1}", Helper.PhotosPath, sdr.GetString(9)),
                        ParentName = sdr.GetString(10),
                        ParentOccuption = sdr.GetString(11),
                        ParentRelationShip = sdr.GetString(12),
                        ParentPhone = sdr.GetString(13),
                        ParentAddress = sdr.GetString(14),
                        ParentEmail = sdr.GetString(15),
                        IsActive = sdr.GetInt32(16) > 0,
                        Color = (Helper.Colour)sdr.GetInt32(17),
                        AddmisionDate = sdr.GetDateTime(18)
                    };
                }
            }

            return null;
        }
        
        public List<Student> Read()
        {
            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Student> students = new List<Student>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Student student = new Student()
                        {
                            ID = sdr.GetInt32(0),
                            FirstName = sdr.GetString(1),
                            LastName = sdr.GetString(2),
                            OtherName = sdr.GetString(3),
                            Gender = (Helper.Gender)sdr.GetInt32(4),
                            DateOfBirth = sdr.GetDateTime(5),
                            ParentName = sdr.GetString(10),
                            ParentPhone = sdr.GetString(13),
                            ParentAddress = sdr.GetString(14),
                            IsActive = sdr.GetInt32(16) > 0,
                            Color = (Helper.Colour)sdr.GetInt32(17)
                        };
                        students.Add(student);
                    }
                }

                return students;
            }
        }

        public bool Update(Student student)
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("UPDATE {0} SET {0}.fname = @fname, {0}.lname = @lname, {0}.oname = @oname, {0}.gender = @gender, {0}.dob = @dob, {0}.email = @email, {0}.address = @adres, {0}.phone = @phone, {0}.img_url = @img, {0}.pname = @pname, {0}.poccup = @occu, {0}.relation = @relation, {0}.pphone = @pphone, {0}.paddress = @padres, {0}.pemail = @pemail, {0}.is_active = @active, {0}.color = @color, {0}.date_admitted = @admitted WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);

                /* Define paramaeters */
                {
                    cmd.Parameters.AddWithValue("@id", student.ID);
                    cmd.Parameters.AddWithValue("@fname", student.FirstName);
                    cmd.Parameters.AddWithValue("@lname", student.LastName);
                    cmd.Parameters.AddWithValue("@oname", student.OtherName);
                    cmd.Parameters.AddWithValue("@gender", student.Gender);
                    cmd.Parameters.AddWithValue("@dob", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@adres", student.Address);
                    cmd.Parameters.AddWithValue("@phone", student.PhoneNo);
                    cmd.Parameters.AddWithValue("@pname", student.ParentName);
                    cmd.Parameters.AddWithValue("@occu", student.ParentOccuption);
                    cmd.Parameters.AddWithValue("@relation", student.ParentRelationShip);
                    cmd.Parameters.AddWithValue("@pphone", student.ParentPhone);
                    cmd.Parameters.AddWithValue("@padres", student.ParentAddress);
                    cmd.Parameters.AddWithValue("@pemail", student.ParentEmail);
                    cmd.Parameters.AddWithValue("@active", student.IsActive);
                    cmd.Parameters.AddWithValue("@color", student.Color);
                    cmd.Parameters.AddWithValue("@admitted", student.AddmisionDate);
                    cmd.Parameters.AddWithValue("@img", Helper.Upload(student.ID, student.Image));
                }

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Student> Search(string key = null)
        {
            key = string.IsNullOrEmpty(key) ? ID.ToString() : key;

            using (Connection)
            {
                string strSql = string.Format("SELECT * FROM {0} WHERE {0}.lname LIKE @key OR {0}.id LIKE @key", Table);
                SqlCommand cmd = new SqlCommand(strSql, Connection);
                cmd.Parameters.AddWithValue("@key", string.Format("%{0}%", key));

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                List<Student> students = new List<Student>();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Student student = new Student()
                        {
                            ID = sdr.GetInt32(0),
                            FirstName = sdr.GetString(1),
                            LastName = sdr.GetString(2),
                            OtherName = sdr.GetString(3),
                            Gender = (Helper.Gender)sdr.GetInt32(4),
                            DateOfBirth = sdr.GetDateTime(5),
                            ParentName = sdr.GetString(10),
                            ParentPhone = sdr.GetString(13),
                            ParentAddress = sdr.GetString(14),
                            IsActive = sdr.GetInt32(16) > 0,
                            Color = (Helper.Colour)sdr.GetInt32(17)
                        };
                        students.Add(student);
                    }
                }

                return students;

            }
        }
    }
}
