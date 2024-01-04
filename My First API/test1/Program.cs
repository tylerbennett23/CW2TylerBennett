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
       
        public static string FinalResponse { get; private set; }
        public static string JSONFile { get; private set; }

        public static void Main(string[] args)
        {
            MakePostRequest().Wait();
            try
            {
                // Call the custom method to get the FinalResponse
                FinalResponse = MakePostRequest().Result;

                // Now, you can use the 'finalResponse' string as needed
                Console.WriteLine($"Response: {FinalResponse}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Add a Console.ReadLine() to keep the console window open
           // Console.ReadLine();

            CreateHostBuilder(args).Build().Run();
            //_ = postAPIAsync();
        }

        //string FinalResponse = null;

        private static readonly HttpClient client = new HttpClient();

        public static object ApiHandler { get; private set; }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async Task<string> MakePostRequest()
        {
            // Replace the URL with the actual endpoint you want to send the POST request to
            string apiUrl = "https://web.socem.plymouth.ac.uk/COMP2001/auth/api/users";

            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Prepare the data you want to send in the request body (as JSON, for example)
                string jsonContent = "{\"email\":\"grace@plymouth.ac.uk\",\"password\":\"ISAD123!\"}";
                JSONFile = jsonContent;
                // Create the HttpContent with the JSON data
                HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                try
                {
                    // Send the POST request
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Check if the request was successful (status code 200-299)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and return the response content
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return responseContent;
                    }
                    else
                    {
                        // Handle error cases if needed
                        throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions if needed
                    throw new HttpRequestException($"Exception: {ex.Message}");
                }
            }
        }
    }
}
