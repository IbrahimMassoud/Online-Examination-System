using Application.Manage_Subject;
using Data;
using Domain;
using System.Linq;


namespace Application.Manage_Question
{
    public class ManageQuestion : IManageQuestion
    {
        private readonly IManageSubject IManageSubject;
        private readonly FacultyDBContext Dbcontext;

        public ManageQuestion(IManageSubject IManageSubject, FacultyDBContext Dbcontext)
        {
            this.IManageSubject = IManageSubject;
            this.Dbcontext = Dbcontext;
        }

        public void AddQuestion(int subjectId,QuestionDTO question)
        {
            Dbcontext.Question.Add(
                 new Question()
                 {
                     _Question = question.Question,
                     ChoiceA = question.ChoiceA,
                     ChoiceB = question.ChoiceB,
                     ChoiceC = question.ChoiceC,
                     ChoiceD = question.ChoiceD,
                     CorrectAnswer = question.CorrectAnswer,
                     SubjectId = question.SubjectId
                 });
            Dbcontext.SaveChanges();
        }

        public void DeleteQuestion(int questionId)
        {
            Dbcontext.Question.Where(Q => Q.Id == questionId).SingleOrDefault().IsDeleted = true;
            Dbcontext.SaveChanges();
        }

        public void EditQuestion(QuestionDTO question)
        {
            var targetQuestion = Dbcontext.Question.Where(Q => Q.Id == question.QuestionId).FirstOrDefault();
            if(targetQuestion is Question)
            {
                targetQuestion._Question = question.Question;
                targetQuestion.ChoiceA = question.ChoiceA;
                targetQuestion.ChoiceB = question.ChoiceB;
                targetQuestion.ChoiceC = question.ChoiceC;
                targetQuestion.ChoiceD = question.ChoiceD;
                targetQuestion.CorrectAnswer = question.CorrectAnswer;
                Dbcontext.SaveChanges();
            }
        }

        public QuestionDTO GetQuestion(int questionId)
        {
            var targetQuestion = Dbcontext.Question.Where(Q => Q.Id == questionId).SingleOrDefault();
            return new QuestionDTO
            {
                Question = targetQuestion._Question,
                ChoiceA = targetQuestion.ChoiceA,
                ChoiceB = targetQuestion.ChoiceB,
                ChoiceC = targetQuestion.ChoiceC,
                ChoiceD = targetQuestion.ChoiceD,
                CorrectAnswer = targetQuestion.CorrectAnswer,
                SubjectId = targetQuestion.SubjectId
            };
        }

        public QuestionDTOList GetQuestions(int subjectId)
        {
            var questions = Dbcontext.Question.Where(Q => Q.IsDeleted == false && Q.SubjectId == subjectId);
            return new QuestionDTOList
            {
                Questions = questions.Select(q =>
                new QuestionDTO
                {
                    QuestionId = q.Id,
                    Question = q._Question,
                    ChoiceA = q.ChoiceA,
                    ChoiceB = q.ChoiceB,
                    ChoiceC = q.ChoiceC,
                    ChoiceD = q.ChoiceD,
                    CorrectAnswer = q.CorrectAnswer,
                    SubjectId = q.SubjectId
                }).ToList()
                ,
                QuestionsCount = questions.Count()
            };
        }
    }
}
