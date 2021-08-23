using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_Teacher
{
   public class TeacherDTO
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }
        
        public int FacultyId { get; set; }

        public int SubjectCount { get; set; }

        public bool IsDeleted { get; set; }

        public int SubjectId { get; set; }

    }

    public class TeacherDTOList
    {
        public List<TeacherDTO> Teachers { get; set; }

        public int TeachersCount { get; set; }
    }




}
