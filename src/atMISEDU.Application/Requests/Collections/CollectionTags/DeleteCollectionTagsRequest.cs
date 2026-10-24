using atMISEDU.Contract.Abstractions;

namespace atMISEDU.Application.Requests.Collections.CollectionTags
{
    public class DeleteCollectionTagsRequest : ICommand
    {
        public int? Id { get; set; }
    }
}