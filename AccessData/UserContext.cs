using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccessDataLayer
{
    /// <summary>
    /// Clase que setea la configuracion 
    /// del contexto con la db
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Expresión de la tabla Users en la db
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        /// <summary>
        /// Sobreescritura del método para crear la tabla
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Usuario");
        }
    }
}
