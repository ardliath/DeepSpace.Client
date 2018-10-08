using Newtonsoft.Json;

namespace DeepSpace.Client.Messages
{
    public class RepairShipRequest
    {
        [JsonProperty(PropertyName = "commandCode")]
        public string CommandCode { get; set; }
    }
}