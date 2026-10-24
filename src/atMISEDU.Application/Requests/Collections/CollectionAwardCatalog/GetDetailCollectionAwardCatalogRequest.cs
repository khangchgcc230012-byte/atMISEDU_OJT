using atMISEDU.Contract.Abstractions;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.Requests.Collections.CollectionAwardCatalog
{
    public class GetDetailCollectionAwardCatalogRequest : IQuery<Entities.CollectionAwardCatalog>
    {
        public int? Id { get; set; }
    }
}