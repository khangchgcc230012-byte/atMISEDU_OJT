using atMISEDU.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace atMISEDU.Application.Requests.Collections.CollectionAwardCatalog
{
    public class UpdateCollectionAwardCatalogRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? AwardName { get; set; }
        public string? AwardDescription { get; set; }
        public string? AwardIcon { get; set; }
        public int? AwardPoint { get; set; }
        public byte? IsActived { get; set; }
    }
}