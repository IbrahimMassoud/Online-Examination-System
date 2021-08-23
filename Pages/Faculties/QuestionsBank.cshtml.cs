using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Manage_Question;
using Application.Manage_Subject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExaminationSystemProject.Pages.Faculties
{
    public class QuestionsBankModel : PageModel
    {
        [BindProperty]
        public QuestionDTOList Questions { get; set; }
        public int QuestionsCount { get; set; }
        public int TotalMark { get; set; }
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }

        private readonly IManageQuestion IManageQuestion;
        private readonly IManageSubject IManageSubject;

        public QuestionsBankModel(IManageQuestion IManageQuestion, IManageSubject IManageSubject)
        {
            this.IManageQuestion = IManageQuestion;
            this.IManageSubject = IManageSubject;
        }
        public void OnGet(int subjectId)
        {
            Questions = IManageQuestion.GetQuestions(subjectId);
            QuestionsCount = Questions.QuestionsCount;
            TotalMark = IManageSubject.GetSubjectById(subjectId);
            SubjectName = IManageSubject.GetSubjectName(subjectId);
            SubjectId = subjectId;
        }
    }
}
