using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ManageStudent
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int FacultyId { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class StudentDTOList
    {
        public List<StudentDTO> Students { get; set; }
        public int StudentsCount { get; set; }
        public int StudentId { get; set; }
    }
}
