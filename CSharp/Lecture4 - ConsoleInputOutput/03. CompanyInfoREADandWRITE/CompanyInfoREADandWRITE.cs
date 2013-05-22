using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompanyInfoREADandWRITE
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("phone: ");
        ulong companyPhone = ulong.Parse(Console.ReadLine());
        Console.Write("fax: ");
        ulong companyFax = ulong.Parse(Console.ReadLine());
        Console.Write("website: ");
        string companyWebSite = Console.ReadLine();
        Console.WriteLine("\n\nmanager: ");
        Console.Write("first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.Write("phone number: ");
        ulong managerPhone = ulong.Parse(Console.ReadLine());
    }
}
