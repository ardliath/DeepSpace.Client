using DeepSpace.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
            using (IDeepSpaceClient client = new DeepSpaceClient("http://localhost:51530/api/ship/"))
            {
                var entCC = "5388820d-6daa-4d3e-97b6-4bc02f718e20";
                //var entCC = await client.CreateShipAsync("USS Enterprise");
                //var rCC = await client.CreateShipAsync("USS Reliant");
                var scanResults = await client.ScanAsync(entCC);
                var moveResult = await client.MoveAsync(entCC, scanResults.Ships.Single().Location);
            }
        }


    }   
}
