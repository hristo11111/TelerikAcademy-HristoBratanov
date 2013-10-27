using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01.ASP.NET_Essentials.Controllers
{
    public class CalcItem
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class CalculatorController : Controller
    {
        double[] results = new double[18];

        List<SelectListItem> types = new List<SelectListItem>()
            {
                new SelectListItem() { Value="0", Text= "bit - b"},
                new SelectListItem() { Value="1", Text= "Byte - B"},
                new SelectListItem() { Value="2", Text="Kilobit - Kb"},
                new SelectListItem() { Value="3", Text="Kilobyte - KB"},
                new SelectListItem() { Value="4", Text="Megabit - Mb"},
                new SelectListItem() { Value="5", Text="Megabyte - MB"},
                new SelectListItem() { Value="6", Text="Gigabit - Gb"},
                new SelectListItem() { Value="7", Text="Gigabyte - GB"},
                new SelectListItem() { Value="8", Text="Terabit - Tb"},
                new SelectListItem() { Value="9", Text="Terabyte - TB"},
                new SelectListItem() { Value="10", Text="Petabit - Pb"},
                new SelectListItem() { Value="11", Text="Petabyte - PB"},
                new SelectListItem() { Value="12", Text="Exabit - Eb"},
                new SelectListItem() { Value="13", Text="Exabyte - EB"},
                new SelectListItem() { Value="14", Text="Zettabit - Zb"},
                new SelectListItem() { Value="15", Text="Zettabyte - ZB"},
                new SelectListItem() { Value="16", Text="Yottabit - Yb"},
                new SelectListItem() { Value="17", Text="Yottabyte - YB"},
            };

        List<SelectListItem> kilos = new List<SelectListItem>()
            {
                new SelectListItem() {Value="0", Text="1000"},
                new SelectListItem() {Value="1", Text="1024"}
            };

        //
        // GET: /Calculator/
        [HttpGet]
        public ActionResult BitCalculator()
        {
            ViewBag.Types = new SelectList(types, "Value", "Text", 5);
            ViewBag.Kilos = new SelectList(kilos, "Value", "Text", 0);

            return View();
        }

        [HttpPost]
        public ActionResult BitCalculator(string quantity, string type, string kilo)
        {
            ViewBag.Types = new SelectList(types, "Value", "Text", 5);
            ViewBag.Kilos = new SelectList(kilos, "Value", "Text", 0);

            var quantityParsed = int.Parse(quantity);
            var selectedType = int.Parse(types.Single(t => t.Value == type).Value);
            var selectedKilo = int.Parse(kilos.Single(k => k.Value == kilo).Text);
            int stepOdd = 125;
            int stepEven = 8;

            results[selectedType] = 1;

            if (selectedType % 2 != 0)
            {
                
            }
            else
            {
                for (int i = selectedType; i < 18; i++)
                {
                    results[i] = 1 / (quantityParsed);
                }
            }

            this.ViewBag.Results = results;

            return View();
        }

    }
}