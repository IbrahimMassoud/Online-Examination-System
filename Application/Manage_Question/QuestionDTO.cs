using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_Question
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string CorrectAnswer { get; set; }
        public int SubjectId { get; set; }

    }
    public class QuestionDTOList
    {
        public QuestionDTOList()
        {
            Questions = new List<QuestionDTO>();    
        }

        public List<QuestionDTO> Questions;
        public int QuestionsCount { get; set; }
    }
}
