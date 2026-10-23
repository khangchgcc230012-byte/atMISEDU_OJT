using atMISEDU.Contract.Abstractions;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.Requests.Collections.CollectionTags
{
    public class GetAllCollectionTagsRequest : IQuery<IQueryable<Entities.CollectionTags>>
    {
        public byte? IsActived { get; set; }
    }
}