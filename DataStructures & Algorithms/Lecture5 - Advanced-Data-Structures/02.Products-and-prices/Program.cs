using System;
using Wintellect.PowerCollections;

class Program
{
    static void Main(string[] args)
    {
        OrderedBag<Product> products = new OrderedBag<Product>();

        for (int i = 0; i < 500000; i++)
        {
            products.Add(new Product("Product" + i, i + 0.5));
        }

        var output = products.Range(new Product("", 5), true, new Product("", 26), true);
        foreach (Product item in output)
        {
            Console.WriteLine(item.Name + " - " + item.Price);
        }
    }
}
