using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Teacher
    {
        public Teacher()
        {
            Subjects = new List<Subject>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }


        public List<Subject> Subjects { get; set; }







    }
}
