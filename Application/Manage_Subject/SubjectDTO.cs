using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_Subject
{
    public class SubjectDTO
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }

        public int TotalMark { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class SubjectDTOList
    {
        public List<SubjectDTO> Subjects { get; set; }
        public int SubjectsCount { get; set; }
    }
}
