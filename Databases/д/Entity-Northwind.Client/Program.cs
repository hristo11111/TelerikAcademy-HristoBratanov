using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext_Northwind;
using System.Globalization;

namespace Entity_Northwind.Client
{
    class Program
    {
        static void Main()
        {
            //TASK2. Create a DAO class with static methods which provide functionality for inserting, 
            //modifying and deleting customers. Write a testing class.

            //InsertCustomer("ABCDE", "Microsoft", "Gosho Goshev", "Manager", "Drujba 3",
            //    "Sofia", "Mladost", "5417", "Bulgaria", "0882545454", "055487521");
            //ModifyCustomerName("ABCDE", "Petio Peshev");
            //DeleteCustomer("ABCDE");

            //TASK3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
            //FindCustomersSpecificOrders("1997", "Canada");

            //TASK4. Implement previous by using native SQL query and executing it through the DbContext.
            //FindCustomersSpecificOrders_SQL("1997", "Canada");

            //TASK5. Write a method that finds all the sales by specified region and period (start / end dates).
            //FindSales("OR", new DateTime(1990, 01, 01), new DateTime(2000, 06, 06));
        }

        private static void FindSales(string region, DateTime orderedDate, DateTime shippedDate)
        {
            NorthwindEntities context = new NorthwindEntities();


            var sales =
                from sale in context.Orders
                where sale.ShipRegion == region && 
                    sale.OrderDate >= orderedDate &&
                    sale.ShippedDate <= shippedDate
                select sale;

            foreach (var item in sales)
            {
                Console.WriteLine(item.ShipName + " --> " + item.OrderDate);
            }
        }

        private static void FindCustomersSpecificOrders_SQL(string year, string country)
        {
            NorthwindEntities context = new NorthwindEntities();
            string sqlQuery = @"SELECT c.ContactName from Customers" +
                              " c INNER JOIN Orders o ON o.CustomerID = c.CustomerID " +
                              "WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

            object[] parameters = { year, country };
            var sqlQueryResult = context.Database.SqlQuery<string>(sqlQuery, parameters);

            foreach (var order in sqlQueryResult)
            {
                Console.WriteLine(order);
            }
            
        }

        private static void FindCustomersSpecificOrders(string year, string country)
        {
            NorthwindEntities context = new NorthwindEntities();
            int yearInt = int.Parse(year);
            var orders =
                from order in context.Orders
                where (int)order.OrderDate.Value.Year == yearInt && order.ShipCountry == country
                select order;

            Console.WriteLine("Customer            OrderedYear ShipCountry");
            foreach (var item in orders)
            {
                Console.WriteLine("{0,-17}       {1}        {2}", 
                    item.Customer.ContactName, item.OrderDate.Value.Year, item.ShipCountry);
            }
        }

        private static void DeleteCustomer(string customerId)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = GetCustomerById(customerId, context);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }

        private static Customer GetCustomerById(string customerId, NorthwindEntities context)
        {
            Customer customer = context.Customers.Find(customerId);
            return customer;
        }

        private static void InsertCustomer(string id, string companyName, string contactName, 
            string contactTitle, string address, string city, string region, 
            string postalCode, string country, string phone, string fax)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = new Customer()
            {
                CustomerID = id,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        private static void ModifyCustomerName(string customerId, string customerName)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = GetCustomerById(customerId, context);
            customer.ContactName = customerName;
            context.SaveChanges();
        }

        //class OrderIdDateCoutnry
        //{
        //    public int ID { get; set; }
        //    public DateTime date { get; set; }
        //    public string country { get; set; }
        //}
    }
}
