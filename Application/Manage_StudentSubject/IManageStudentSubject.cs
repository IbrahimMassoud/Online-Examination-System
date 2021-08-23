using Application.ManageStudent;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_StudentSubject
{
    public interface IManageStudentSubject
    {
        List<StudentSubject> GetGrade(int subjectId);
        StudentDTOList GetStudentsBySubjectId(int subjectId);
        void AddNewStudentSubject(int subjectId);

    }
}
