using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Manage_Faculty;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CompanyProject.Pages.Faculties
{
    public class DeleteFacultyModel : PageModel
    {
        public FacultyDTO Faculty { get; set; }
        private readonly IManageFaculty IManageFaculty;
        public DeleteFacultyModel(IManageFaculty IManageFaculty)
        {
            this.IManageFaculty = IManageFaculty;
        }
        public void OnGet(int facultyId)
        {
            Faculty = IManageFaculty.GetFacultyById(facultyId);
        }
        public IActionResult OnPost(int facultyId)
        {
            IManageFaculty.DeleteFaculty(facultyId);

            return RedirectToPage("./FacultiesList");
        }
    }
}
