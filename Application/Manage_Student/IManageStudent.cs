using Application.ManageStudent;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ManageEmployee
{
    public interface IManageStudent
    {
        StudentDTOList GetStudents(int facultyId);
        void AddStudent(int facultyId, StudentDTO student);
        StudentDTO GetStudentById(int studentId);
        void EditStudent(StudentDTO student);
        void DeleteStudent(int studentId);
    }
}
