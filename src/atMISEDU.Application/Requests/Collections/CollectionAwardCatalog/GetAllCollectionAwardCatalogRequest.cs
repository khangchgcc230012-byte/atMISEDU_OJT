using atMISEDU.Contract.Abstractions;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.Requests.Collections.CollectionAwardCatalog
{
    public class GetAllCollectionAwardCatalogRequest : IQuery<IQueryable<Entities.CollectionAwardCatalog>>
    {
        public byte? IsActived { get; set; }
    }
}