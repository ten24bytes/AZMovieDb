using System.Data.Entity;

namespace AZMovieDB.Models
{
    public class AzMovieDbEntities : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}