using System.Collections.Generic;

namespace AZMovieDB.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }

        public Genre Genre { get; set; }
        public List<Actor> Actors { get; set; }
    }
}