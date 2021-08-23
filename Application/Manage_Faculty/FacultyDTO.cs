using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_Faculty
{
    public class FacultyDTO
    {
        public string Name { get; set; }
        public string University { get; set; }
        public int Id { get; set; }
        public int studentsCount { get; set; }
    }
    public class FacultyDTOList
    {
        public List<FacultyDTO> Faculties { get; set; }
        public int FacultiesCount { get; set; }
    }
}
