using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using FeedZillaArtSearch;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Console.Write("Query string: ");
        string queryString = Console.ReadLine();
        Console.Write("Articles count: ");
        int count = int.Parse(Console.ReadLine());

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/");

        GetArticles(client, queryString, count);

        Console.ReadLine();
    }

    private async static void GetArticles(HttpClient client, string queryString, int count)
    {
        var response = await client.GetAsync("search.json?q=" + queryString + "&count=" + count);

        string json = await response.Content.ReadAsStringAsync();

        var fzRezult = JsonConvert.DeserializeObject<FZResult>(json);

        var articles = fzRezult.Articles;

        foreach (var article in articles)
        {
            Console.WriteLine("TITLE: " + article.Title + "\nURL: " + article.Url);
            Console.WriteLine(new string('-', 50));
        }

        Console.Write("Press any key to exit!");
    }
}
