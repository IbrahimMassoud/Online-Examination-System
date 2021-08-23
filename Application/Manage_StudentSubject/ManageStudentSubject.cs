using Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain;
using Application.ManageStudent;
using Microsoft.EntityFrameworkCore;

namespace Application.Manage_StudentSubject
{
  public class ManageStudentSubject:IManageStudentSubject
    {
        private readonly FacultyDBContext Dbcontext;
        public ManageStudentSubject(FacultyDBContext DbContext)
        {
            this.Dbcontext = DbContext;
        }

        public List<StudentSubject> GetGrade( int subjectId)
        {
             var grad =Dbcontext.StudentSubjects.Where(ss=>ss.SubjectId== subjectId).ToList();
            return grad;
        }

        public StudentDTOList GetStudentsBySubjectId(int subjectId)
        {
            var students = Dbcontext.StudentSubjects.Include(s=>s.Student).Include(s1=>s1.Subject).
                Where(s => s.SubjectId == subjectId && s.IsDeleted==false )
                .ToList();

            return new StudentDTOList
            {
                Students = students.Select(s => new StudentDTO
                {
                    Name = s.Student.Name,
                    Address = s.Student.Address,
                    Age = s.Student.Age,
                    Id = s.Student.Id,
                    FacultyId=s.Student.FacultyId,
                    IsDeleted=s.Student.IsDeleted
                }).ToList(),
                StudentsCount = students.Count,
                
            };
        }
        public void AddNewStudentSubject( int subjectId)
        {
            var studentId= Dbcontext.Students.Max(s => s.Id);
            var studentubject = new StudentSubject
            {
                StudentId = studentId,
                SubjectId= subjectId
            };
            Dbcontext.StudentSubjects.Add(studentubject);
            Dbcontext.SaveChanges();
        }
    }
}
