using _02.LibrarySystem.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.LibrarySystem.Areas.Administration.Controllers
{
    public class BooksController : Controller
    {
        List<Book> books = new List<Book>()
        {
            new Book() {Title = "1001 Nights Tales", Author="Ali Baba"},
            new Book() {Title = "Adventures of Tom Sawer", Author="Mark Twain"}
        };
        //
        // GET: /Administration/Books/
        public ActionResult GetAll()
        {
            return View(books);
        }
	}
}