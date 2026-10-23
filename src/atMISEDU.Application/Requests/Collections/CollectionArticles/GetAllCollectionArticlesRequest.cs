using atMISEDU.Contract.Abstractions;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.Requests.Collections.CollectionArticles
{
    public class GetAllCollectionArticlesRequest : IQuery<IQueryable<Entities.CollectionArticles>>
    {
        public byte? IsActived { get; set; }
        public int? KeyTags { get; set; }
    }
}