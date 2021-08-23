using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.ManageEmployee;
using Application.ManageStudent;
using Application.Manage_StudentSubject;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CompanyProject.Pages.Companies.Employees
{
    public class EditStudentModel : PageModel
    {
        private readonly IManageStudent IManageStudent;
        private readonly IManageStudentSubject IManageStudentSubject;
        [BindProperty]
        public StudentDTO Student { get; set; }
        [BindProperty]
        public int facultyId { get; set; }
        public EditStudentModel(IManageStudent IManageStudent, IManageStudentSubject IManageStudentSubject)
        {
            this.IManageStudent = IManageStudent;
            this.IManageStudentSubject = IManageStudentSubject;

        }
        public void OnGet(int? studentId, int facultyId)
        {
            if (!studentId.HasValue)
            {
                Student = new StudentDTO();
            }
            else
            {
                Student = IManageStudent.GetStudentById(studentId.Value);
            }
            this.facultyId = facultyId;
        }
        public IActionResult OnPost( int subjectId)
        {
            if (Student.Id > 0)
            {
                IManageStudent.EditStudent(Student);
            }
            else
            {
                IManageStudent.AddStudent(facultyId, Student);
                IManageStudentSubject.AddNewStudentSubject(subjectId);
            }
            return RedirectToPage("./FacultiesList");
        }
    }
}
