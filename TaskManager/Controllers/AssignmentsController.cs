using BLL;
using BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers;

[ApiController]
[Route("[controller]")]
public class AssignmentsController : ControllerBase
{
    [Route("[action]")]
    [HttpPut]
    public AssignmentDTO Create(AssignmentCreatingBody body) => AssignmentBl.CreateAssignment(body.Title, body.Description, body.ProjectId);

    [Route("[action]")]
    [HttpGet]
    public IEnumerable<AssignmentDTO> Read() => AssignmentBl.GetAllAssignment();

    [Route("[action]")]
    [HttpGet]
    public IEnumerable<string> GetPossibleStatuses() => AssignmentBl.GetPossibleStatuses();

    [Route("[action]")]
    [HttpPatch]
    public AssignmentDTO Update(AssignmentUpdatingBody body) => AssignmentBl.UpdateAssignment(body.Id, body.Title, body.Description, body.Status);

    [Route("[action]")]
    [HttpDelete]
    public bool Delete(AssignmentDeletingBody body) => ProjectBL.DeleteProject(body.Id);


}

public class AssignmentDeletingBody
{
    public int Id { get; set; }
}

public class AssignmentCreatingBody
{
    public int ProjectId { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";
}

public class AssignmentUpdatingBody
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Description { get; set; } = "";

    public string Status { get; set; } = "";
}

