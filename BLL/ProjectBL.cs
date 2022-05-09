using BLL.DTO;
using DAL.Model;
using DAL.Repository;

namespace BLL;

public static class ProjectBL
{
    private static readonly UnitOfWork _work = new();

    public static List<ProjectDTO> GetAllProjects() =>
        _work.ProjectRepository
        .Read()
        .ToList()
        .ConvertAll(p => DTOConverter.ToProjectDTO(p));

    public static List<ProjectDTO> FindProject(string searchText) =>
        _work.ProjectRepository
        .Filter(p => p.Title.Contains(searchText) || p.Description.Contains(searchText))
        .ToList()
        .ConvertAll(p => DTOConverter.ToProjectDTO(p));

    public static ProjectDTO CreateProject(string title, string description)
    {
        Project project = new()
        {
            Title = title,
            Description = description
        };

        _work.ProjectRepository.Create(project);
        _work.Save();

        return DTOConverter.ToProjectDTO(project);
    }

    public static ProjectDTO UpdateProject(int projectId, string title, string description)
    {
        Project? project = _work.ProjectRepository.Find(p => p.Id == projectId);

        if (project is null)
            throw new Exception();

        project.Title = title;
        project.Description = description;

        _work.ProjectRepository.Update(project);
        _work.Save();

        return DTOConverter.ToProjectDTO(project);
    }

    public static bool DeleteProject(int projectId)
    {
        Project? project = _work.ProjectRepository.Find(p => p.Id == projectId);

        if (project is null)
            return false;

        _work.ProjectRepository.Delete(project);
        _work.Save();

        return true;
    }
}
