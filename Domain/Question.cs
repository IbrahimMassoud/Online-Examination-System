using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string _Question { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string CorrectAnswer { get; set; }
        public bool IsDeleted { get; set; }
        public int SubjectId { get; set; }

    }
}
