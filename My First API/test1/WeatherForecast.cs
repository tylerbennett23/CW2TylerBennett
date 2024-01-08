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
        public string Data { get; set; }

        public string ResponsAPI { get; set; }

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
                Console.WriteLine("Nah this aint working buddy, it aint posting");
            }
        }
        
    }
}
