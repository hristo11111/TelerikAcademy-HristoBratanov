using System;
using System.Linq;
using TelerikAcademy.Data;

namespace TelerikAcademy.Client
{
    public class ConsoleAcademy
    {
        static void Main()
        {
            // Task 1: Using iclude method:
            PrintEmployeesInfo_IncludeMethod();

            // Task 2: Without using of include method:
            PrintEmployeesInfo_WithoutIncludeMethod();

            // Task 3: ToList() for each property
            GetSofiaMatches_ManyToList();

            // Task 4: ToList() once
            GetSofiaMatches_OnceToList();
            
        }

        private static void GetSofiaMatches_OnceToList()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            var employees = context.Employees.
                Select(ad => ad.Address).
                Select(t => t.Town).
                Where(t => t.Name == "Sofia").ToList();
            Console.WriteLine("There are {0} matches", employees.Count());
        }

        private static void GetSofiaMatches_ManyToList()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            var employees = context.Employees.ToList().
                Select(ad => ad.Address).ToList().
                Select(t => t.Town).ToList().
                Where(t => t.Name == "Sofia");
            Console.WriteLine("There are {0} matches", employees.Count());
        }

        private static void PrintEmployeesInfo_WithoutIncludeMethod()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            using (context)
            {
                foreach (var empl in context.Employees)
                {
                    Console.WriteLine("{0} - works at - {1} - from - {2}", empl.FirstName + " " + empl.LastName,
                        empl.Department.Name, empl.Address.Town.Name);
                }
            }
        }

        private static void PrintEmployeesInfo_IncludeMethod()
        {
            TelerikAcademyEntities context = new TelerikAcademyEntities();
            using (context)
            {
                foreach (var employee in context.Employees.Include("Department").Include("Address.Town"))
                {
                    Console.WriteLine("{0} - works at - {1} - from - {2}", employee.FirstName + " " + employee.LastName,
                        employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }
    }        
}
