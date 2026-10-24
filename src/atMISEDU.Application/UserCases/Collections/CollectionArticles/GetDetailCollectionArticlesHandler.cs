using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionArticles
{
    public class GetDetailCollectionArticlesHandler : IRequestHandler<GetDetailCollectionArticlesRequest, Result<Entities.CollectionArticles>>
    {
        private readonly ICollectionArticlesSqlRepository articleRepo;

        public GetDetailCollectionArticlesHandler(ICollectionArticlesSqlRepository articleRepo)
        {
            this.articleRepo = articleRepo;
        }

        public async Task<Result<Entities.CollectionArticles>> Handle(GetDetailCollectionArticlesRequest request, CancellationToken cancellationToken)
        {
            var article = articleRepo.FindAll(x => x.Id.Equals(request.Id) && x.IsActived != 2).FirstOrDefault();
            if (article == null)
            {
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionArticles), MsgCode.ERR_COLLECTION_ARTICLES_ID_NOT_FOUND);
            }
            return article;
        }
    }
}