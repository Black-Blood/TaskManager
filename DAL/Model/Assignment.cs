using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model;

[Table("Assignments")]
public class Assignment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Description { get; set; }
    public virtual Status Status { get; set; }
    public virtual List<Project> Projects { get; set; } = new();
}

public enum Status
{
    NotStarted,
    Doing,
    Finished
}