using atMISEDU.Contract.Abstractions;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.Requests.Collections.CollectionTags
{
    public class GetDetailCollectionTagsRequest : IQuery<Entities.CollectionTags>
    {
        public int? Id { get; set; }
    }
}