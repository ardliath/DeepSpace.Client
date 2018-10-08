using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DeepSpace.Client.Messages;
using Newtonsoft.Json;

namespace DeepSpace.Client
{
    public class DeepSpaceClient : IDeepSpaceClient
    {
        protected HttpClient HttpClient { get; set; }
        public string BaseUrl { get; }

        public DeepSpaceClient(string baseUrl)
        {
            this.HttpClient = new HttpClient();
            this.BaseUrl = baseUrl;
        }

        public async Task<CreateShipResponse> CreateShipAsync(string name)
        {
            using (var client = new HttpClient())
            {
                var address = GetCommand("create");
                var payload = string.Concat("{name: '", name, "'}");
                var data = await PostDataAsync(address, payload);
                return JsonConvert.DeserializeObject<CreateShipResponse>(data);
            }
        }

        protected string GetCommand(string commandName)
        {
            return string.Concat(this.BaseUrl, commandName);
        }


        private async Task<string> PostDataAsync(string address, string payload)
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

        public void Dispose()
        {            
        }
    }
}
