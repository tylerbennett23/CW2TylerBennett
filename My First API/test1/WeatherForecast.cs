using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.Text;

namespace test1
{
    public class WeatherForecast
    {
               
        public string Email{ get; set; }
        public string Password{ get; set; }

        private static readonly HttpClient client = new HttpClient();

        public async Task postAPIAsync()
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

                // Console.WriteLine(responseString);

                Debug.WriteLine(responseString);

            }
            catch {
                Console.WriteLine("Nah this aint working buddy");
            }
        }
        /*
        static async Task PostAsync(HttpClient httpClient)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    userId = 77,
                    id = 1,
                    title = "write code sample",
                    completed = false
                }),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync(
                "todos",
                jsonContent);

            response.EnsureSuccessStatusCode()
                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
        }
        

        JSONObject reservation = new JSONObject();

        */
    }
}
