using BLL.DTO;
using DAL.Model;
using DAL.Repository;

namespace BLL;

public static class AssignmentBl
{
    private static readonly UnitOfWork _work = new();

    public static List<AssignmentDTO> GetAllAssignment() =>
        _work.AssignmentRepository
        .Read()
        .ToList()
        .ConvertAll(a => DTOConverter.ToAssignmentDTO(a));

    public static List<AssignmentDTO> FindAssignment(string searchText) =>
        _work.AssignmentRepository
        .Filter(a => a.Title.Contains(searchText) || a.Description.Contains(searchText))
        .ToList()
        .ConvertAll(a => DTOConverter.ToAssignmentDTO(a));

    public static AssignmentDTO CreateAssignment(string title, string description, int projectId)
    {
        Assignment assignment = new()
        {
            Title = title,
            Description = description,
            Status = Status.Created,
            ProjectId = projectId
        };

        _work.AssignmentRepository.Create(assignment);
        _work.Save();

        return DTOConverter.ToAssignmentDTO(assignment);
    }

    public static AssignmentDTO UpdateAssignment(int id, string title, string description, string status)
    {
        Assignment? assignment = _work.AssignmentRepository.Find(a => a.Id == id);

        if (assignment is null)
            throw new Exception();

        assignment.Title = title;
        assignment.Description = description;
        assignment.Status = (Status) Enum.Parse(typeof(Status), status);

        _work.AssignmentRepository.Update(assignment);
        _work.Save();

        return DTOConverter.ToAssignmentDTO(assignment);
    }

    public static bool DeleteAssignment(int assignmentId)
    {
        Assignment? assignment = _work.AssignmentRepository.Find(a => a.Id == assignmentId);

        if (assignment is null)
            return false;

        _work.AssignmentRepository.Delete(assignment);
        _work.Save();

        return true;
    }

    public static string[] GetPossibleStatuses() => Enum.GetNames(typeof(Status));
}
