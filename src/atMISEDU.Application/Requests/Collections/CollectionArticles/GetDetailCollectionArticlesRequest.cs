using atMISEDU.Contract.Abstractions;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.Requests.Collections.CollectionArticles
{
    public class GetDetailCollectionArticlesRequest : IQuery<Entities.CollectionArticles>
    {
        public int? Id { get; set; }
    }
}