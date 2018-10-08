using Newtonsoft.Json;

namespace DeepSpace.Client.Messages
{
    public class CreateShipRequest
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}