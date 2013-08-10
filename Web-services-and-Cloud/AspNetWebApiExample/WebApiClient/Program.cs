using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:19170/")
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
                client.GetAsync("api/BlogPosts").Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content
                    .ReadAsAsync<IEnumerable<Post>>().Result;
                foreach (var p in products)
                {
                    Console.WriteLine("{0,4} {1,-20}",
                        p.Title, p.Content);
                }
            }
            else
                Console.WriteLine("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase);

        }
    }
}
