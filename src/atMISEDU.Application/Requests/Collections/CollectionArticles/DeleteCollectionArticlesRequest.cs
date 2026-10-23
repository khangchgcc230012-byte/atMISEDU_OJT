using atMISEDU.Contract.Abstractions;

namespace atMISEDU.Application.Requests.Collections.CollectionArticles
{
    public class DeleteCollectionArticlesRequest : ICommand
    {
        public int? Id { get; set; }
    }
}