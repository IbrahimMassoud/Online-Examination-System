using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public int FacultyId { get; set; }
    }
}
