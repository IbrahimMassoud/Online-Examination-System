using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_ExamResult
{
    public class ExamResultDTO
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
    }
}
