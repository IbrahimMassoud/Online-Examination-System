using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.ManageEmployee;
using Application.ManageStudent;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CompanyProject.Pages.Companies.Employees
{
    public class DeleteStudentModel : PageModel
    {
        public StudentDTO Student { get; set; }
        private readonly IManageStudent IManageStudent;
        public DeleteStudentModel(IManageStudent IManageStudent)
        {
            this.IManageStudent = IManageStudent;
        }
        public void OnGet(int studentId)
        {
            Student = IManageStudent.GetStudentById(studentId);
        }
        public IActionResult OnPost(int studentId)
        {
            IManageStudent.DeleteStudent(studentId);
            return RedirectToPage("./FacultiesList");
        }
    }
}
