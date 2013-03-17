using System.Linq;
using System.Web.Mvc;
using AZMovieDB.Models;

namespace AZMovieDB.Controllers
{
    public class MovieController : Controller
    {
        private readonly AzMovieDbEntities _movieDb = new AzMovieDbEntities();

        //
        // GET: /Movie/
        public ActionResult Index()
        {
            var genres = _movieDb.Genres.ToList();

            return View(genres);
        }

        //
        // GET: /Movie/Browse?genre=Fantasy
        public ActionResult Browse(string genre)
        {
            var genreModel = _movieDb.Genres.Include("Movies")
                                     .Single(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Movie/Details/5
        public ActionResult Details(int id)
        {
            var movie = _movieDb.Movies.Find(id);

            return View(movie);
        }
    }
}