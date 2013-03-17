using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AZMovieDB.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<AzMovieDbEntities>
    {
        protected override void Seed(AzMovieDbEntities context)
        {
            var genres = new List<Genre>
                             {
                                 new Genre {Name = "Horror"},
                                 new Genre {Name = "Action"},
                                 new Genre {Name = "Comedy"},
                                 new Genre {Name = "Adventure"},
                                 new Genre {Name = "Musical"},
                                 new Genre {Name = "Fantasy"},
                                 new Genre {Name = "Fiction"},
                                 new Genre {Name = "Sci-Fi"},
                                 new Genre {Name = "Romance"},
                                 new Genre {Name = "Thriller"},
                                 new Genre {Name = "Documentary"},
                                 new Genre {Name = "Biography"}
                             };

            var actors = new List<Actor>
                             {
                                 new Actor {Name = "Ashton Kutcher"},
                                 new Actor {Name = "Bruce Willis"},
                                 new Actor {Name = "Hugh Jackman"},
                                 new Actor {Name = "Kate Winslet"},
                                 new Actor {Name = "Ryan Phillippe"},
                                 new Actor {Name = "Anne Hathaway"},
                                 new Actor {Name = "Edward Norton"},
                                 new Actor {Name = "Will Smith"},
                                 new Actor {Name = "Tommy Lee Jones"},
                                 new Actor {Name = "Brad Pitt"},
                                 new Actor {Name = "Christian Bale"},
                                 new Actor {Name = "Johnny Depp"},
                                 new Actor {Name = "Gary Oldman"},
                                 new Actor {Name = "Arnold Schwarzenegger"},
                                 new Actor {Name = "Leonardo DiCaprio"},
                                 new Actor {Name = "Heath Ledger"}
                             };

            new List<Movie>
                {
                    new Movie
                        {
                            Title = "Men in Black",
                            Genre = genres.Single(g => g.Name == "Sci-Fi"),
                            Actors =
                                actors.Where(x => x.Name == "Will Smith" || x.Name == "Tommy Lee Jones").ToList()
                        },
                    new Movie
                        {
                            Title = "Armageddon",
                            Genre = genres.Single(g => g.Name == "Sci-Fi"),
                            Actors = actors.Where(x => x.Name == "Bruce Willis").ToList()
                        },
                    new Movie
                        {
                            Title = "Jobs",
                            Genre = genres.Single(g => g.Name == "Biography"),
                            Actors = actors.Where(x => x.Name == "Ashton Kutcher").ToList()
                        },
                    new Movie
                        {
                            Title = "The Imaginarium of Doctor Parnassus",
                            Genre = genres.Single(g => g.Name == "Fantasy"),
                            Actors = actors.Where(x => x.Name == "Johnny Depp" || x.Name == "Heath Ledger").ToList()
                        },
                    new Movie
                        {
                            Title = "The Dark Knight",
                            Genre = genres.Single(g => g.Name == "Fiction"),
                            Actors =
                                actors.Where(
                                    x =>
                                    x.Name == "Christian Bale" || x.Name == "Heath Ledger" || x.Name == "Gary Oldman")
                                      .ToList()
                        },
                    new Movie
                        {
                            Title = "Titanic",
                            Genre = genres.Single(g => g.Name == "Romance"),
                            Actors =
                                actors.Where(x => x.Name == "Leonardo DiCaprio" || x.Name == "Kate Winslet").ToList()
                        },
                    new Movie
                        {
                            Title = "Fight Club",
                            Genre = genres.Single(g => g.Name == "Thriller"),
                            Actors = actors.Where(x => x.Name == "Brad Pitt" || x.Name == "Edward Norton").ToList()
                        },
                    new Movie
                        {
                            Title = "Les Misérables",
                            Genre = genres.Single(g => g.Name == "Musical"),
                            Actors =
                                actors.Where(x => x.Name == "Hugh Jackman" || x.Name == "Anne Hathaway").ToList()
                        },
                }.ForEach(a => context.Movies.Add(a));
        }
    }
}