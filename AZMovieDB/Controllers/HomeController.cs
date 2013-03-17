using System;
using System.Linq;
using System.Web.Mvc;
using AZMovieDB.Models;

namespace AZMovieDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AzMovieDbEntities _movieDb = new AzMovieDbEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var movies = _movieDb.Movies.Take(5).ToList();

            return View(movies);
        }

    }
}