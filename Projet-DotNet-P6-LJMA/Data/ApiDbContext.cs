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
    public DbSet<PostPhilo> PostPhilos { get; set; }
    public DbSet<Randonnee> Randonnees { get; set; }
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    public DbSet<Vlog> Vlogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostPhilo>().ToTable("PostPhilo");
        modelBuilder.Entity<Vlog>().ToTable("Vlog");
        modelBuilder.Entity<Session>().ToTable("Session");
        modelBuilder.Entity<Reserver>().ToTable("Reserver");


        #region Relation des FOREIGN KEY

        modelBuilder.Entity<Reserver>()
            .HasOne(r => r.Session)
            .WithMany()
            .HasForeignKey(r => r.id_session);

        modelBuilder.Entity<Reserver>()
           .HasOne(r => r.Utilisateur)
           .WithMany()
           .HasForeignKey(r => r.id_utilisateur);

        modelBuilder.Entity<Session>()
            .HasOne(s => s.Theme)
            .WithMany()
            .HasForeignKey(s => s.id_theme);

        modelBuilder.Entity<Session>()
            .HasOne(s => s.Randonnee)
            .WithMany()
            .HasForeignKey(s => s.id_rando);
        #endregion
    }
}