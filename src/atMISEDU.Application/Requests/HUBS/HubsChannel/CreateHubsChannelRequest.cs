using atMISEDU.Contract.Abstractions;
using atMISEDU.Contract.Enumerations;
using System.Text.Json.Serialization;

namespace atMISEDU.Application.Requests.HUBS.HubsChannel
{
    public class CreateHubsChannelRequest : ICommand
    {
        public string CnName { get; set; } = string.Empty;
        public string CnUrl { get; set; } = string.Empty;
        public string CnIcon { get; set; } = string.Empty;
        public string CnStyle { get; set; } = string.Empty;
        public int? CnOrder { get; set; }

        [JsonIgnore]
        public int? IsActived { get; set; } = (int)ActivedType.ACTIVED;
    }
}