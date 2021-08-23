using System;
using System.Collections.Generic;
using System.Text;
using Application;
using Application.Manage_Faculty;
using Domain;

namespace Application
{
    public interface IManageFaculty
    {
        void AddFaculty(FacultyDTO newFaculty);
        FacultyDTOList GetFaculties();
        FacultyDTO GetFacultyById(int facultyId);
        void DeleteFaculty(int facultyId);
        void EditFaculty(FacultyDTO faculty);
    }

}
