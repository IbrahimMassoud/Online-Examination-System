using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Manage_Question;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExaminationSystemProject.Pages.Faculties
{
    public class AddEditQuestionModel : PageModel
    {
        private readonly IManageQuestion IManageQuestion;
        [BindProperty]
        public QuestionDTO Question { get; set; }
        [BindProperty]
        public Question _tempQuestion { get; set; }
        public AddEditQuestionModel(IManageQuestion IManageQuestion)
        {
            this.IManageQuestion = IManageQuestion;
        }
        public void OnGet(int? questionId, int subjectId)
        {
            if (!questionId.HasValue)
            {
                _tempQuestion = new Question();
                Question = new QuestionDTO();
                Question.QuestionId = _tempQuestion.Id;
                Question.SubjectId = subjectId;

            }
            else
            {
                Question = IManageQuestion.GetQuestion(questionId.Value);
            }
        }
        public IActionResult OnPost(int subjectId)
        {
            if (Question.QuestionId > 0)
            {
                IManageQuestion.EditQuestion(Question);
            }
            else
            {
                IManageQuestion.AddQuestion(subjectId, Question);
            }

            return RedirectToPage("./FacultiesList");
        }
    }
}
