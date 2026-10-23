using atMISEDU.Contract.Abstractions;

namespace atMISEDU.Application.Requests.Collections.CollectionTags
{
    public class CreateCollectionTagsRequest : ICommand
    {
        public string? TagName { get; set; }
        public string? TagSlug { get; set; }
        public string? TagDescription { get; set; }
        public string? TagColor { get; set; }
        public int? CreatedBy { get; set; }
        public byte? IsActived { get; set; } = 1;
    }
}