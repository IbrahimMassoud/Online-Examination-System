using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int QuestionId { get; set; }
        public string Answer  { get; set; }
    }
}
