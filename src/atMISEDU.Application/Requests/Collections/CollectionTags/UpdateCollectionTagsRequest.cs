using atMISEDU.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace atMISEDU.Application.Requests.Collections.CollectionTags
{
    public class UpdateCollectionTagsRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? TagName { get; set; }
        public string? TagSlug { get; set; }
        public string? TagDescription { get; set; }
        public string? TagColor { get; set; }
        public byte? IsActived { get; set; }
    }
}