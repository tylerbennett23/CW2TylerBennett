using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Diagnostics;



namespace test1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            _ = postAPIAsync();
        }

        private static readonly HttpClient client = new HttpClient();


        static async Task postAPIAsync()
        {
            try
            {
                var values = new Dictionary<string, string>
            {
                {"Email", "grace@plymouth.ac.uk" },
                {"Password", "ISAD132!" }
            };
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://web.socem.plymouth.ac.uk/COMP2001/auth/api/users", content);

                var responseString = await response.Content.ReadAsStringAsync();

                 Console.WriteLine(responseString);

                Debug.WriteLine(responseString);

            }
            catch
            {
                Console.WriteLine("Nah this aint working buddy");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
