using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLMB_SMS.Models
{
    class Grade
    {
        #region Properties
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public int StudintID { get; set; }
        public int YearID { get; set; }
        public int Term { get; set; }
        public float TestOne { get; set; }
        public float TestTwo { get; set; }
        public float Min { get; set; }


        #endregion

        public Grade()
        {

        }

        public bool Create()
        {
            return false;
        }

        public Grade Read(int id)
        {
            return this;
        }

        public List<Grade> Read()
        {
            return new List<Grade>();
        }

        public bool Update()
        {
            return false;
        }
    }
}
