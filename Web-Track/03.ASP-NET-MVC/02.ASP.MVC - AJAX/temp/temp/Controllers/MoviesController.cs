using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using temp.Models;

namespace temp.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesTempDbContext db = new MoviesTempDbContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.LeadingFemaleActor).Include(m => m.LeadingMaleActor);
            return View(movies.ToList());
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAjaxRequest())
            {
                Movie movie = db.Movies.Find(id);

                return PartialView("_MovieDetails", movie);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movieFound = db.Movies.Find(id);
            if (movieFound == null)
            {
                return HttpNotFound();
            }
            return View(movieFound);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            ViewBag.LeadingFemaleId = new SelectList(db.Actors, "Id", "Name");
            ViewBag.LeadingMaleId = new SelectList(db.Actors, "Id", "Name");
            return View();
        }

        // POST: /Movies/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeadingFemaleId = new SelectList(db.Actors, "Id", "Name", movie.LeadingFemaleId);
            ViewBag.LeadingMaleId = new SelectList(db.Actors, "Id", "Name", movie.LeadingMaleId);
            return View(movie);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeadingFemaleId = new SelectList(db.Actors, "Id", "Name", movie.LeadingFemaleId);
            ViewBag.LeadingMaleId = new SelectList(db.Actors, "Id", "Name", movie.LeadingMaleId);
            return View(movie);
        }

        // POST: /Movies/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeadingFemaleId = new SelectList(db.Actors, "Id", "Name", movie.LeadingFemaleId);
            ViewBag.LeadingMaleId = new SelectList(db.Actors, "Id", "Name", movie.LeadingMaleId);
            return View(movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
