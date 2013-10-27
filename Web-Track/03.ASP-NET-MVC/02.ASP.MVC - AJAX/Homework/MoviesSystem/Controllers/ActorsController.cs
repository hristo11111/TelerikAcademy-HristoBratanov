using MoviesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesSystem.Controllers
{
    public class ActorsController : Controller
    {
        private MoviesDBContext db = new MoviesDBContext();
        public ActionResult Index(int? id)
        {
            if (id != null && Request.IsAjaxRequest())
            {
                var moviesFemale = db.Movies.Where(m => m.LeadingFemaleRole.Id == id).ToList();
                var moviesMale = db.Movies.Where(m => m.LeadingMaleRole.Id == id).ToList();
                var movies = new List<Movie>();
                movies.AddRange(moviesFemale);
                movies.AddRange(moviesMale);

                return PartialView("_MoviesPartialEachActor", movies);
            }

            var actors = db.Actors.ToList();

            return View(actors);
        }
	}
}