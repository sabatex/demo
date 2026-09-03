using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTPClientDemo
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var url = new UriBuilder();
                url.Port = 80;
                url.Host = "sqlite.org";
                url.UserName = "laslo";
                url.Password = "maslo";
                url.Query = "param=10";
                url.Scheme = "http";



                var h = client.DefaultRequestHeaders;
                h.Add("Content-Language", "ru-RU");
                HttpResponseMessage response = await client.GetAsync(url.Uri);
                var responseMSG = response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
