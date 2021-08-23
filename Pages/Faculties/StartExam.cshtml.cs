using Application.Manage_ExamResult;
using Application.Manage_Question;
using Application.Manage_Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExaminationSystemProject.Pages.Faculties
{
    public class StartExamModel : PageModel
    {
        private readonly IManageQuestion IManageQuestion;
        private readonly IManageSubject IManagesubject;
        private readonly IManageExamResult IManageExamResult;
        public string SubjectName { get; set; }
        public int TotalMark { get; set; }

        public QuestionDTOList Questions { get; set; }
        [BindProperty]
        public string CorrectAnswer  { get; set; }
        //public string[] Choices;

        public StartExamModel(IManageQuestion IManageQuestion, IManageSubject IManagesubject ,
            IManageExamResult IManageExamResult)
        {
            this.IManageQuestion = IManageQuestion;
            this.IManagesubject = IManagesubject;
            this.IManageExamResult = IManageExamResult;
        }
        public void OnGet(int subjectId ,int questionId)
        {
            Questions = IManageQuestion.GetQuestions(subjectId);
            SubjectName = IManagesubject.GetSubjectName(subjectId);
            TotalMark = IManagesubject.GetSubjectById(subjectId);
        }

        public void OnPost(int subjectId)
        {
            Questions = IManageQuestion.GetQuestions(subjectId);
            SubjectName = IManagesubject.GetSubjectName(subjectId);
            TotalMark = IManagesubject.GetSubjectById(subjectId);
            IManageExamResult.AddAnswer(
                new ExamResultDTO()
                {
                    Answer = CorrectAnswer,
                    SubjectId = subjectId
                }
);
        }
    }
}

