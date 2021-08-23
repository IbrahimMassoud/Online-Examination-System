using System;
using System.Collections.Generic;


namespace Domain
{
    public class Faculty
    {
        public Faculty()
        {
            Students = new List<Student>();
        }
        public List<Student> Students { get; set; }
        public string Name { get; set; }
        public string University { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; } 
    }
}
