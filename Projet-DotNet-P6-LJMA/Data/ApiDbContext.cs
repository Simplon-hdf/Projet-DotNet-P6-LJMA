using Microsoft.EntityFrameworkCore;
using Projet_DotNet_P6_LJMA.Models;

namespace Projet_DotNet_P6_LJMA.Data;
/// <summary>
/// Cette classe permet d'intéragir avec la BDD.
/// </summary>
public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    { 
    }

    public DbSet<Theme> Themes { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Reserver> Reservers { get; set; }
    public DbSet<Post_philo> Post_Philos { get; set; }
    public DbSet<Randonnee> Randonnees { get; set; }
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Vlog> Vlogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Theme>().ToTable("Theme");
        modelBuilder.Entity<Session>().ToTable("Session");
        modelBuilder.Entity<Reserver>().ToTable("Reserver");
        modelBuilder.Entity<Post_philo>().ToTable("Post_Philos");
        modelBuilder.Entity<Randonnee>().ToTable("Randonnee");
        modelBuilder.Entity<Utilisateur>().ToTable("Utilisateur");
        modelBuilder.Entity<Vlog>().ToTable("Vlog");
    }
}