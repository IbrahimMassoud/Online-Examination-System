using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_ExamResult
{
    public class ManageExamResult : IManageExamResult
    {
        private readonly FacultyDBContext Dbcontext;
        public ManageExamResult(FacultyDBContext Dbcontext)
        {
            this.Dbcontext = Dbcontext;
        }

        public void AddAnswer(ExamResultDTO answer)
        {
            Dbcontext.ExamResults.Add(
                new Domain.ExamResult()
                {
                    Answer = answer.Answer,
                    QuestionId = answer.QuestionId,
                    SubjectId = answer.SubjectId
                });
            Dbcontext.SaveChanges();
        }
    }
}
