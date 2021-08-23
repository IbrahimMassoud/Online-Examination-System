using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Manage_Teacher
{
    public interface IManageTeacher
    {

       TeacherDTOList GetTeachers();

      TeacherDTO GetTeacherbyId(int TeacherId);


        void DeleteTeacher(int TeacherId);


    }
}
