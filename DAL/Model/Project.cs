using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model;

[Table("Projects")]
public class Project
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual Guid Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Description { get; set; }
    public virtual List<Assignment> Assignments { get; set; } = new();
}