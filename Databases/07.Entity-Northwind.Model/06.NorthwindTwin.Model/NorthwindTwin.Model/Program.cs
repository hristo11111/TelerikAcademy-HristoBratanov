using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTwin.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities db = new NorthwindEntities();

            using(db)
	        {
		        Product product = new Product();
                product.ProductName = "kokalche";

                db.Products.Add(product);
                db.SaveChanges();
	        }

            
        }
    }
}
