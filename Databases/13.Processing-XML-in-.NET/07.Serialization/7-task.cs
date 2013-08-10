using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace _07.Serialization
{
    class Program
    {
        static void Main()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("PhoneNumber: ");
            ulong phoneNumber = ulong.Parse(Console.ReadLine());

            Person person = new Person();

            person.Name = name;
            person.Address = address;
            person.PhoneNumber = phoneNumber;

            XmlSerializer serializer = new XmlSerializer(person.GetType());

            TextWriter writer = new StreamWriter("../../person.xml");
            serializer.Serialize(writer, person);
            Console.WriteLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ulong PhoneNumber { get; set; }
    }
}
