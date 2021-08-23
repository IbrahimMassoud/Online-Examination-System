using System;
using System.Collections.Generic;
using System.Linq;
using Application.Manage_Faculty;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class ManageFaculty : IManageFaculty
    {
        private readonly FacultyDBContext Dbcontext;
        public ManageFaculty(FacultyDBContext DBbcontext)
        {
            this.Dbcontext = DBbcontext;
        }
        void IManageFaculty.AddFaculty(FacultyDTO newFaculty)
        {
            Dbcontext.Add(
                new Faculty()
                {
                    Name = newFaculty.Name,
                    University = newFaculty.University,
                }
                );
            Dbcontext.SaveChanges();
        }
        public FacultyDTOList GetFaculties()
        {
            var faculties = Dbcontext.Faculties.Include(f=>f.Students).Where(f=>f.IsDeleted==false).ToList();
            return new FacultyDTOList()
            {
                Faculties = faculties.Select(c=> new FacultyDTO                 //select one company of list then use
                {
                    Name = c.Name,
                    University = c.University,
                    Id = c.Id,
                    studentsCount = c.Students.Where(e=>e.IsDeleted==false).Count()
                }).ToList()
                ,
                FacultiesCount = faculties.Count
            };
        }

        public FacultyDTO GetFacultyById(int facultyId)
        {
            return GetFaculties().Faculties.SingleOrDefault(f => f.Id == facultyId);
        }

        public void DeleteFaculty(int facultyId)
        {
           Dbcontext.Faculties.SingleOrDefault(f => f.Id == facultyId).IsDeleted=true;
           Dbcontext.SaveChanges();
        }

        public void EditFaculty(FacultyDTO faculty)
        {
            var _object = Dbcontext.Faculties.SingleOrDefault(f => f.IsDeleted == false && f.Id == faculty.Id);
            if (_object != null)
            {
                _object.Name = faculty.Name;
                _object.University = faculty.University;
                Dbcontext.SaveChanges();
            }
        }
    }
}
