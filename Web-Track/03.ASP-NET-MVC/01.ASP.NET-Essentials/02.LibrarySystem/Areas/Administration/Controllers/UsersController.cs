using _02.LibrarySystem.Areas.Administration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02.LibrarySystem.Areas.Administration.Controllers
{
    public class UsersController : Controller
    {
        List<Customer> users = new List<Customer>()
        {
            new Customer() {Name="Pesho Ivanov", Age = 5},
            new Customer() {Name="Gosho Petkov", Age = 15},
            new Customer() {Name="Aneliq Atanasova", Age = 22}
        };
        //
        // GET: /Administration/Users/
        public ActionResult GetAll()
        {
            return View(users);
        }
	}
}