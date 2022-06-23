using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AZMovieDB.Models;
using EntityState = System.Data.Entity.EntityState;

namespace AZMovieDB.Controllers
{
    public class MovieManagerController : Controller
    {
        private readonly AzMovieDbEntities _movieDb = new AzMovieDbEntities();

        //
        // GET: /MovieManager/

        public ActionResult Index()
        {
            var movies = _movieDb.Movies.Include(m => m.Genre);

            return View(movies.ToList());
        }

        //
        // GET: /MovieManager/Details/5

        public ActionResult Details(int id = 0)
        {
            var movie = _movieDb.Movies
                                .Include(a => a.Actors)
                                .Include(g => g.Genre)
                                .FirstOrDefault(m => m.MovieId == id);

            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        //
        // GET: /MovieManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_movieDb.Genres, "GenreId", "Name");

            return View();
        }

        //
        // POST: /MovieManager/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieDb.Movies.Add(movie);
                _movieDb.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(_movieDb.Genres, "GenreId", "Name", movie.GenreId);

            return View(movie);
        }

        //
        // GET: /MovieManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var movie = _movieDb.Movies
                                .Include(a => a.Actors)
                                .SingleOrDefault(m => m.MovieId == id);

            if (movie == null) return HttpNotFound();

            ViewBag.GenreId = new SelectList(_movieDb.Genres, "GenreId", "Name", movie.GenreId);

            return View(movie);
        }

        //
        // POST: /MovieManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieDb.Entry(movie).State = EntityState.Modified;
                _movieDb.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(_movieDb.Genres, "GenreId", "Name", movie.GenreId);

            return View(movie);
        }

        //
        // GET: /MovieManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var movie = _movieDb.Movies.Find(id);

            if (movie == null) return HttpNotFound();

            return View(movie);
        }

        //
        // POST: /MovieManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var movie = _movieDb.Movies.Find(id);

            _movieDb.Movies.Remove(movie);
            _movieDb.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _movieDb.Dispose();
            base.Dispose(disposing);
        }
    }
}