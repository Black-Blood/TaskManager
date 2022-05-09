using BLL;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    [Route("[action]")]
    [HttpPut]
    public ProjectDTO Create(ProjectCreatingBody body) => ProjectBL.CreateProject(body.Title, body.Description);

    [Route("[action]")]
    [HttpGet]
    public IEnumerable<ProjectDTO> Read() => ProjectBL.GetAllProjects();

    [Route("[action]")]
    [HttpPatch]
    public ProjectDTO Update(ProjectUpdatingBody body) => ProjectBL.UpdateProject(body.Id, body.Title, body.Description);

    [Route("[action]")]
    [HttpDelete]
    public bool Delete(ProjectDeletingBody body) => ProjectBL.DeleteProject(body.Id);
}

public class ProjectDeletingBody
{
    public int Id { get; set; }
}

public class ProjectCreatingBody
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";
}

public class ProjectUpdatingBody
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";
}
