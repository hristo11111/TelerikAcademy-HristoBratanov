using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {
        Article art1 = new Article("ShowerGel", "Nivea", 15166456464, 4.5);
        Article art2 = new Article("ShowerGel2", "Nivea2", 15446456464, 5.2);
        Article art3 = new Article("ShowerGel3", "Nivea2", 15162216464, 4.5);

        OrderedMultiDictionary<double, Article> list = new OrderedMultiDictionary<double, Article>(true);
        list.Add(art1.Price, art1);
        list.Add(art2.Price, art2);
        list.Add(art3.Price, art3);

        double rangeFrom = 4.5;
        double rangeTo = 5;
        var output = list.Range(rangeFrom, true, rangeTo, true);

        Console.WriteLine("The articles in range {0} - {1} are: ", rangeFrom, rangeTo);
        foreach (var item in output.Values)
        {
            Console.WriteLine(item);
        }
    }
}
