namespace Application.Manage_Subject
{
    public interface IManageSubject
    {
      int GetSubjectById(int SubjectId);
      string GetSubjectName(int SubjectId);
      SubjectDTOList GetAllSubjects();

    }
}
