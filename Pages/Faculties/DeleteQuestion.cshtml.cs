using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Manage_Question;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExaminationSystemProject.Pages.Faculties
{
    public class DeleteQuestionModel : PageModel
    {
        private readonly IManageQuestion IManageQuestion;
        [BindProperty]
        public QuestionDTO Question { get; set; }
        public int MyProperty { get; set; }
        public DeleteQuestionModel(IManageQuestion IManageQuestion)
        {
            this.IManageQuestion = IManageQuestion;
        }

        public void OnGet(int questionId)
        {
            Question = IManageQuestion.GetQuestion(questionId);
        }
        public IActionResult OnPost(int questionId)
        {
            IManageQuestion.DeleteQuestion(questionId);

            return RedirectToPage("./FacultiesList");
        }
    }
}
