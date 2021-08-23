using Application.ManageStudent;
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.ManageEmployee
{
    public class ManageStudent : IManageStudent
    {
        private readonly FacultyDBContext Dbcontext;
        private readonly IManageFaculty IManageFaculty;

        public ManageStudent(FacultyDBContext Dbcontext, IManageFaculty IManageFaculty)
        {
            this.Dbcontext = Dbcontext;
            this.IManageFaculty = IManageFaculty;
        }
        public StudentDTOList GetStudents(int facultyId)
        {
            var students = Dbcontext.Students.
                Where(/*s => s.FacultyId == facultyId &&*/s=> s.IsDeleted == false)
                .ToList();
            return new StudentDTOList
            {
                Students = students.Select(s=> new StudentDTO
                { 
                Name=s.Name,
                Address = s.Address,
                Age = s.Age,
                Id = s.Id,
                }).ToList(),
                StudentsCount = students.Count
            };
        }

        

        public void AddStudent(int facultyId, StudentDTO student)
        {
     
            var relatedFaculty = Dbcontext.Faculties.Where(f => f.Id == facultyId && f.IsDeleted == false).SingleOrDefault();
            relatedFaculty.Students.Add(new Student()
            {
                Name = student.Name,
                Address = student.Address,
                Age = student.Age,
                FacultyId= facultyId

            });
            Dbcontext.SaveChanges();
            #region OldCode
            //var relatedCompany = IManageCompany.GetCompanyById(companyId);
            //relatedCompany.Employees.Add(new Employee()
            //{
            //    Name = employee.Name,
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    Salary = employee.Salary
            //}); 
            #endregion

            
        }

        public StudentDTO GetStudentById(int studentId)
        {
            var student = Dbcontext.Students.FirstOrDefault(e => e.Id == studentId && e.IsDeleted == false);
            return new StudentDTO()
            {
                Name = student.Name,
                Id = student.Id,
                Address = student.Address,
                 Age = student.Age,
            };
        }
        public void EditStudent(StudentDTO student)
        {
            var stud = Dbcontext.Students.SingleOrDefault(s => s.Id == student.Id && s.IsDeleted == false);

            stud.Name = student.Name;
            stud.Age = student.Age;
            stud.Address = student.Address;
            Dbcontext.SaveChanges();
        }
        public void DeleteStudent(int studentId)
        {
            var student = Dbcontext.Students.SingleOrDefault(s => s.Id == studentId && s.IsDeleted == false);
            student.IsDeleted = true;
            var studentSubject = Dbcontext.StudentSubjects.SingleOrDefault(s => s.StudentId == studentId && s.IsDeleted == false);
            studentSubject.IsDeleted = true;
            Dbcontext.SaveChanges();
        }
    }
}
