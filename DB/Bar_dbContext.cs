using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class Bar_dbContext : DbContext
    {
        public Bar_dbContext(DbContextOptions<Bar_dbContext> options)
            : base(options) // pasamos al padre las options usando 'base'
        {

        }

        // especificamos las clases que tenemos con 'DbSet<clase>'
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brand> Brands { get; set; }

        // nos permite modificar las tablas de la base de datos.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // cambia los nombres de las tablas a singular 'Beers' => 'Beer'
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Beer>().ToTable("Beer");
        }
    }
}