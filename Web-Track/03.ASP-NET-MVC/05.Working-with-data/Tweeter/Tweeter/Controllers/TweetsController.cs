using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tweeter.Models;
using Tweeter.Data;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace Tweeter.Controllers
{
    public class TweetsController : Controller
    {
        IUowData db;

        public TweetsController(IUowData db)
        {
            this.db = db;
        }

        public TweetsController()
        {
            db = new UowData();
        }

        // GET: /Admin/
        public ActionResult Index()
        {
            return View(db.Tweets.All().OrderByDescending(t => t.DateTweeded).ToList());
        }

        [Authorize]
        // GET: /Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // GET: /Admin/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Tweet tweet)
        {
            if (!String.IsNullOrEmpty(tweet.Content) && tweet != null)
            {
                tweet.DateTweeded = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = db.Users.All().FirstOrDefault(x => x.UserName == User.Identity.Name);
                    tweet.User = user;
                    db.Tweets.Add(tweet);

                    var tagsMatches= Regex.Matches(tweet.Content, "(\\#\\S+)");

                    var tags = new HashSet<Tag>();
                    for (int i = 0; i < tagsMatches.Count; i++)
                    {
                        var newTag = tagsMatches[i].Value;

                        var tag = db.Tags.All().FirstOrDefault(t => t.Name == newTag);
                        if (tag == null)
	                    {
                            tags.Add(new Tag { Name = newTag });
	                    }
                        else
                        {
                            tags.Add(tag);
                        }
                    }
                    tweet.Tags = tags;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(tweet);
        }

        // GET: /Admin/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            if (tweet.User.Id != User.Identity.GetUserId())
            {
                if (!User.IsInRole("Administrator"))
                {
                    return HttpNotFound();
                }
            }
            return View(tweet);
        }

        // POST: /Admin/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Tweets.Update(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        // GET: /Admin/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.Tweets.GetById(id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            if (tweet.User.Id != User.Identity.GetUserId())
            {
                if (!User.IsInRole("Administrator"))
                {
                    return HttpNotFound();
                }
            }
            return View(tweet);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.Tweets.GetById(id);
            db.Tweets.Delete(tweet);
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
