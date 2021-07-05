using Microsoft.EntityFrameworkCore;

namespace Infra.Model.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=./sam_database.sqlite");

        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cautela>().Ignore(t => t.Materiais);
            modelBuilder.Entity<Usuario>().Ignore(t => t.Credentials);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cautela> Cautela { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Militar> Militar { get; set; }
        public DbSet<Cautela_Material> Cautela_Material { get; set; }
        public DbSet<Usuario_Credential> Usuario_Credential { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Log> Log { get; set; }
    }
}
