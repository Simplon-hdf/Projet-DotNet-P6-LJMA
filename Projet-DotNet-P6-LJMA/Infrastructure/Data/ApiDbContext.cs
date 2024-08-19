using Microsoft.EntityFrameworkCore;
using Projet_DotNet_P6_LJMA.Infrastructure.Data.Models;

namespace Projet_DotNet_P6_LJMA.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Reserver> Reservers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Randonnee> Randonnees { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Vlog> Vlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Utilisateur>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}