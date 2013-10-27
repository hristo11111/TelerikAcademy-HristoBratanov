using MoviesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MoviesSystem.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDBContext db = new MoviesDBContext();
        public ActionResult Index(int? id)
        {
            if (id != null && Request.IsAjaxRequest())
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == id);

                return PartialView("_ActorsPartial", movie);
            }

            var movies = db.Movies.ToList();
            return View(movies);
        }

        public ActionResult Search(string query)
        {
            IList<Movie> moviesByTitle = null;
            if (query == string.Empty)
            {
                moviesByTitle = db.Movies.ToList();
            }
            else
	        {
                moviesByTitle = db.Movies.Where
                (m => m.Title.ToLower().Contains(query.ToLower())).ToList();
	        }

            return PartialView("_MoviesPartial", moviesByTitle);
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == id);

                var list = new List<Movie>();
                list.Add(movie);

                return PartialView("_MoviesPartial", list);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var actors = db.Actors;

            return View(actors);
        }

        [HttpPost]
        public ActionResult Create(string title, string director, DateTime? year,
            string leadingFemaleRole, string leadingMaleRole)
        {
            Actor femaleRole = db.Actors.FirstOrDefault(a => a.Name == leadingFemaleRole);
            Actor maleRole = db.Actors.FirstOrDefault(a => a.Name == leadingMaleRole);

            Movie newMovie = new Movie()
            {
                Title = title,
                Director = director,
                Year = (DateTime)year,
                LeadingFemaleRole = femaleRole,
                LeadingMaleRole = maleRole
            };

            db.Movies.Add(newMovie);
            db.SaveChanges();

            var actors = db.Actors;

            return RedirectToAction("Index");
        }
	}
}