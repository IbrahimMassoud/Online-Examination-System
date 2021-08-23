using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain;
using Application;
using Application.Manage_Faculty;
using Application.Manage_Teacher;

namespace CompanyProject.Pages.Companies
{
    public class FacultiesListModel : PageModel
    {
        public FacultyDTOList facultiesList  { get; set; }

        public TeacherDTOList  TeachersList { get; set; }

        private readonly IManageTeacher IManageTeacher;


        private readonly IManageFaculty IManageFaculty;

        public FacultiesListModel(IManageTeacher IManageTeacher, IManageFaculty IManageFaculty)
        {
            this.IManageTeacher = IManageTeacher;

            this.IManageFaculty = IManageFaculty;
        }
        public void OnGet()
        { 

            TeachersList = IManageTeacher.GetTeachers();
        }
    }
}
