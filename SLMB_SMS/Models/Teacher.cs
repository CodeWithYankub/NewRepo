using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Teacher
    {
        #region Properties
        public int ID { get; set; }
        public int Sector { get; set; }
        public string Name { get; set; }
        public string PinCode { get; set; }
        public Helper.Gender Gender { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public bool IsApproved { get; set; }
        public string KinName { get; set; }
        public string KinAddress { get; set; }
        public string KinPhone { get; set; }
        public string KinEmail { get; set; }
        public string KinRelation { get; set; }
        public DateTime EmployedDate { get; set; }

        private string Table { get { return "teachers"; } }
        private SqlConnection Connection { get; set; }
        #endregion

        public Teacher()
        {
            Connection = new SqlConnection(Helper.ConnectionString);
        }
        
        public bool Exists(string key = null)
        {
            key = string.IsNullOrEmpty(key) ? PinCode : key;

            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {0}.pin = @key OR {0}.sector_id = @key", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@key", key);

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                return sdr.HasRows;
            }
        }

        public bool Create()
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("INSERT INTO {0} VALUES( @sector, @pin, @name, @gender, @email, @adres, @phone, @approved, @nkname, @nkaddress, @nkphone, @nkemail, @nkrelation, @date_employed)", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);

                /* Define paramaeters */
                {
                    cmd.Parameters.AddWithValue("@sector", Sector);
                    cmd.Parameters.AddWithValue("@pin", PinCode);
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@gender", Gender);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@adres", Address);
                    cmd.Parameters.AddWithValue("@phone", PhoneNo);
                    cmd.Parameters.AddWithValue("@approved", IsApproved);
                    cmd.Parameters.AddWithValue("@nkname", KinName);
                    cmd.Parameters.AddWithValue("@nkaddress", KinAddress);
                    cmd.Parameters.AddWithValue("@nkphone", KinPhone);
                    cmd.Parameters.AddWithValue("@nkemail", KinEmail);
                    cmd.Parameters.AddWithValue("@nkrelation", KinRelation);
                    cmd.Parameters.AddWithValue("@Date_employed", EmployedDate);
                   
                }

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
           
        }

        public Teacher Read(int id)
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
                    return new Teacher()
                    {
                        ID = sdr.GetInt32(0),
                        Sector = sdr.GetInt32(1),
                        PinCode = sdr.GetString(2),
                        Name = sdr.GetString(3),
                        Gender = (Helper.Gender)sdr.GetInt32(4),
                        Email = sdr.GetString(5),
                        Address = sdr.GetString(6),
                        PhoneNo = sdr.GetString(7),
                        IsApproved = sdr.GetInt32(8) > 0,
                        KinName = sdr.GetString(9),
                        KinAddress = sdr.GetString(10),
                        KinPhone = sdr.GetString(11),
                        KinEmail = sdr.GetString(12),
                        KinRelation = sdr.GetString(13),
                        EmployedDate = sdr.GetDateTime(14)
                    };
                }
            }
            return null;
        }

        public List<Teacher> Read()
        {
            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0}", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                Connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Teacher> teachers = new List<Teacher>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Teacher teacher = new Teacher()
                        {
                            ID = sdr.GetInt32(0),
                            Sector = sdr.GetInt32(1),
                            PinCode = sdr.GetString(2),
                            Name = sdr.GetString(3),
                            Gender = (Helper.Gender)sdr.GetInt32(4),
                            Address = sdr.GetString(5),
                            Email = sdr.GetString(6),
                            PhoneNo = sdr.GetString(7),
                            IsApproved = sdr.GetInt32(8) > 0,
                            KinName = sdr.GetString(9),
                            KinAddress = sdr.GetString(10),
                            KinPhone = sdr.GetString(11),
                            KinEmail = sdr.GetString(12),
                            KinRelation = sdr.GetString(13),
                            EmployedDate = sdr.GetDateTime(14)
                           
                        };
                        teachers.Add(teacher);
                    }
                }
                return teachers;
            }
           
        }

        public bool Update(Teacher teacher)
        {
            using (Connection = new SqlConnection(Helper.ConnectionString))
            {
                string sql = string.Format("UPDATE {0} SET {0}.sector_id = @sector, {0}.pin = @pin, {0}.name = @name, {0}.gender = @gender, {0}.email = @email, {0}.address = @adres, {0}.phone = @phone, {0}.is_approved = @approved, {0}.nkname = @nkname, {0}.nkaddress = @nkaddress, {0}.nkphone = @nkphone, {0}.nkemail = @nkemail, {0}.nkrelation = @nkrelation, {0}.date_employed = @date_employed WHERE {0}.id = @id", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);

                /* Define paramaeters */
                {
                    cmd.Parameters.AddWithValue("@id", teacher.ID);
                    cmd.Parameters.AddWithValue("@sector", teacher.Sector);
                    cmd.Parameters.AddWithValue("@pin", teacher.PinCode);
                    cmd.Parameters.AddWithValue("@name", teacher.Name);
                    cmd.Parameters.AddWithValue("@gender", teacher.Gender);
                    cmd.Parameters.AddWithValue("@email", teacher.Email);
                    cmd.Parameters.AddWithValue("@adres", teacher.Address);
                    cmd.Parameters.AddWithValue("@phone", teacher.PhoneNo);
                    cmd.Parameters.AddWithValue("@approved", teacher.IsApproved);
                    cmd.Parameters.AddWithValue("@nkname", teacher.KinName);
                    cmd.Parameters.AddWithValue("@nkaddress", teacher.KinAddress);
                    cmd.Parameters.AddWithValue("@nkphone", teacher.KinPhone);
                    cmd.Parameters.AddWithValue("@nkemail", teacher.KinEmail);
                    cmd.Parameters.AddWithValue("@nkrelation", teacher.KinRelation);
                    cmd.Parameters.AddWithValue("@date_employed", teacher.EmployedDate);
                }

                Connection.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Teacher> Search(string key)
        {
            using (Connection)
            {
                string sql = string.Format("SELECT * FROM {0} WHERE {0}.pin LIKE @key OR {0}.name LIKE @key", Table);
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddWithValue("@key", string.Format("%{0}%", key));

                Connection.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                List<Teacher> teachers = new List<Teacher>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Teacher teacher = new Teacher()
                        {
                            ID = sdr.GetInt32(0),
                            Sector = sdr.GetInt32(1),
                            PinCode = sdr.GetString(2),
                            Name = sdr.GetString(3),
                            Gender = (Helper.Gender)sdr.GetInt32(4),
                            Address = sdr.GetString(5),
                            Email = sdr.GetString(6),
                            PhoneNo = sdr.GetString(7),
                            IsApproved = sdr.GetInt32(8) > 0,
                            KinName = sdr.GetString(9),
                            KinAddress = sdr.GetString(10),
                            KinPhone = sdr.GetString(11),
                            KinEmail = sdr.GetString(12),
                            KinRelation = sdr.GetString(13),
                            EmployedDate = sdr.GetDateTime(14)

                        };
                        teachers.Add(teacher);
                    }
                }
                return teachers;
            }

        }
    }
}

