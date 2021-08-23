using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Manage_Faculty;
using Application.ManageEmployee;
using Application.ManageStudent;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application.Manage_Subject;
using Application.Manage_StudentSubject;
namespace CompanyProject.Pages.Companies
{
    public class DetailsModel : PageModel
    {


        public StudentDTOList Students { get; set; }
        public int  subject { get; set; }
        public List<StudentSubject> grad { get; set; }
        public int SubjectId { get; set; }

        private readonly IManageStudent IManageStudent;
        private readonly IManageSubject IManageSubject;
        private readonly IManageStudentSubject IManageStudentSubject  ;
        public DetailsModel(IManageStudent IManageStudent, IManageSubject IManageSubject , IManageStudentSubject IManageStudentSubject)
        {
            this.IManageStudent = IManageStudent;
            this.IManageSubject = IManageSubject;
            this.IManageStudentSubject = IManageStudentSubject;
        }
        public void OnGet(int subjectId)
        {
            SubjectId = subjectId;
            Students = IManageStudentSubject.GetStudentsBySubjectId(subjectId);
            subject = IManageSubject.GetSubjectById(subjectId);
            grad = IManageStudentSubject.GetGrade(subjectId);

        }
    }
}
