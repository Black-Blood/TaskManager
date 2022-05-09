using BLL.DTO;
using DAL.Model;

namespace BLL;

internal static class DTOConverter
{
    public static ProjectDTO ToProjectDTO(Project project) => new()
    {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
    };

    public static AssignmentDTO ToAssignmentDTO(Assignment assignment) => new()
    {
        Id = assignment.Id,
        Title = assignment.Title,
        ProjectId = assignment.ProjectId,
        Description = assignment.Description,
        Status = assignment.Status.ToString(),
    };

    public static Project ToProject(ProjectDTO project) => new()
    {
        Id = project.Id,
        Title = project.Title,
        Description = project.Description,
    };

    public static Assignment ToAssignment(AssignmentDTO assignment) => new()
    {
        Id = assignment.Id,
        Title = assignment.Title,
        ProjectId = assignment.ProjectId,
        Description = assignment.Description,
        Status = (Status) Enum.Parse(typeof(Status), assignment.Status)
    };
}
