using System.Configuration;
using Microsoft.EntityFrameworkCore;
using DAL.Model;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }

    public DbSet<Assignment> Assignments { get; set; }

    public ApplicationDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = ConfigurationManager.ConnectionStrings["ApplicationDbContext"].ToString();
        Console.WriteLine(connection);
        optionsBuilder.UseSqlServer(connection);
    }
}

