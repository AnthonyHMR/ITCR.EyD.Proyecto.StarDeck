using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Services
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
        public DbSet<Carta> Carta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario_Tiene_Carta>().HasKey(c => new { c.id_usuario, c.id_carta });
        }
        public DbSet<RESTAPI.Models.Usuario_Tiene_Carta>? Usuario_Tiene_Carta { get; set; }
    }
}
