using Data;
using System.Linq;


namespace Application.Manage_Subject
{
    public class ManageSubject : IManageSubject
    {
        private readonly FacultyDBContext Dbcontext;
        public ManageSubject(FacultyDBContext DbContext)
        {
            this.Dbcontext = DbContext;
        }
        public SubjectDTOList GetAllSubjects()
        {
            var subjects = Dbcontext.Subjects.Where(sub=>sub.IsDeleted == false);
            return new SubjectDTOList
            {
                Subjects = subjects.Select(sub =>
                new SubjectDTO
                {
                    Name = sub.Name,
                    SubjectId = sub.SubjectId,
                    TotalMark = sub.TotalMark
                }).ToList()
                ,
                SubjectsCount = subjects.Count()
            };
        }

        public int GetSubjectById(int SubjectId)
        {
            var Sub = Dbcontext.Subjects.SingleOrDefault(sub => sub.SubjectId == SubjectId && sub.IsDeleted == false).TotalMark;

            return Sub;
            //SubjectDTO subject=null;
            //subject.Name = Sub.Name;
            //subject.SubjectId = Sub.SubjectId;
            //subject.TotalMark = Sub.TotalMark;
            //subject.IsDeleted = Sub.IsDeleted;
            //return subject;
        }

        public string GetSubjectName(int SubjectId)
        {
            return Dbcontext.Subjects.SingleOrDefault(sub => sub.SubjectId == SubjectId && sub.IsDeleted == false).Name;
        }
    }
}
