using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting Game!");
                Run();                

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private async static void Run()
        {
            var entCC = await CreateShipAsync("USS Enterprise");
            var rCC = await CreateShipAsync("USS Reliant");
        }

        private static  async Task<string> CreateShipAsync(string name)
        {
            using (var client = new HttpClient())
            {
                var address = GetCommand("create");
                var payload = string.Concat("{name: '", name, "'}");
                return await PostDataAsync(address, payload);
            }
        }

        private static string GetCommand(string details)
        {
            var local = true;
               
            var baseAddress = local
                ? "http://localhost:51530/api/ship/"
                : "https://XYZ.azurewebsites.net/api/ship/";

            return string.Concat(baseAddress, details);
        }

        static async Task<string> PostDataAsync(string address, string payload)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(address, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return null;
            }
        }
    }   
}
