using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Manage_Faculty;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CompanyProject.Pages.Companies
{
    public class EditFacultyModel : PageModel
    {
        private readonly IManageFaculty IManageFaculty;

        [BindProperty]
        public FacultyDTO Faculty { get; set; }
        public EditFacultyModel(IManageFaculty IManageFaculty)
        {
            this.IManageFaculty = IManageFaculty;
        }
        public void OnGet(int? facultyId)
        {
            if (!facultyId.HasValue)
            {
                Faculty = new FacultyDTO();
            }
            else
            {
                Faculty = IManageFaculty.GetFacultyById(facultyId.Value);
            }
        }
        public IActionResult OnPost()
        {
            if (Faculty.Id > 0)
            {
                IManageFaculty.EditFaculty(Faculty);
            }
            else
            {
                IManageFaculty.AddFaculty(Faculty);
            }
            return RedirectToPage("./FacultiesList");
        }
    }
}