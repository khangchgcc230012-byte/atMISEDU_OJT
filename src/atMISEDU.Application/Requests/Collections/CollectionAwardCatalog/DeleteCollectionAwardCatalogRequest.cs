using atMISEDU.Contract.Abstractions;

namespace atMISEDU.Application.Requests.Collections.CollectionAwardCatalog
{
    public class DeleteCollectionAwardCatalogRequest : ICommand
    {
        public int? Id { get; set; }
    }
}