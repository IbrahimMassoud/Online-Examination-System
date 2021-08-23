using Application.Manage_Question;
using Application.Manage_Subject;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExaminationSystemProject.Pages.Faculties
{
    public class SubjectsListModel : PageModel
    {
       // [BindProperty]

        public SubjectDTOList Subjects { get; set; }
        public QuestionDTOList Questions { get; set; }
        public int SubjectId { get; set; }

        private readonly IManageSubject IManageSubject;
        private readonly IManageQuestion IManageQuestion;

        public SubjectsListModel(IManageQuestion IManageQuestion, IManageSubject IManageSubject)
        {
            this.IManageSubject = IManageSubject;
            this.IManageQuestion = IManageQuestion;
        }
        public void OnGet()
        {
            Subjects = IManageSubject.GetAllSubjects();
            foreach (var item in Subjects.Subjects)
            {
                SubjectId = item.SubjectId;
            }
            Questions = IManageQuestion.GetQuestions(SubjectId);
        }
    }
}
