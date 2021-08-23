using Application.Manage_Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_Question
{
    public interface IManageQuestion
    {
        QuestionDTOList GetQuestions(int subjectId);
        void AddQuestion(int subjectId, QuestionDTO question);
        void DeleteQuestion(int questionId);
        void EditQuestion(QuestionDTO question);
        QuestionDTO GetQuestion(int questionId);
    }
}
