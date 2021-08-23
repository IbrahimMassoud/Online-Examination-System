using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Subject
    {
        public Subject()
        {
            StudentSubjects = new List<StudentSubject>();
            Questions = new List<Question>();
        }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int TotalMark { get; set; }
        public bool IsDeleted { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
        public List <Question> Questions { get; set; }


    }
}
