using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Manage_Teacher
{
    public class ManageTeacher : IManageTeacher
    {
        private readonly FacultyDBContext Dbcontext;

        public ManageTeacher(FacultyDBContext DBbcontext)
        {
            this.Dbcontext = DBbcontext;
        }

        public void DeleteTeacher(int TeacherId)
        {
            Dbcontext.Teachers.SingleOrDefault(f => f.ID==TeacherId).IsDeleted = true;
            Dbcontext.SaveChanges();
        }



        public TeacherDTO GetTeacherbyId(int TeacherId)
        {
            return GetTeachers().Teachers.SingleOrDefault(f => f.ID == TeacherId);
        }

        public TeacherDTOList GetTeachers()
        {
            var teachers = Dbcontext.Teachers.Include(s=>s.Subjects).Where(f => f.IsDeleted == false).ToList();
            return new TeacherDTOList()
            {
                Teachers = teachers.Select(c => new TeacherDTO              
                {
                    Name = c.Name,

                    ID = c.ID,
                    SubjectCount = c.Subjects.Where(s => s.IsDeleted == false).Count(),
                    Subject = c.Subjects.Where(s => s.IsDeleted == false).First(c1 => c1.SubjectId != 0).Name,
                    SubjectId = c.Subjects.Where(s => s.IsDeleted == false).First(c1 => c1.SubjectId != 0).SubjectId
                }).ToList()
               
                
            };
        }
    }
}
