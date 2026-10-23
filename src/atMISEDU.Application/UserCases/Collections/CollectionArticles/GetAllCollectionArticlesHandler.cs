using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionArticles
{
    public class GetAllCollectionArticlesHandler : IRequestHandler<GetAllCollectionArticlesRequest, Result<IQueryable<Entities.CollectionArticles>>>
    {
        private readonly ICollectionArticlesSqlRepository articleRepo;

        public GetAllCollectionArticlesHandler(ICollectionArticlesSqlRepository articleRepo)
        {
            this.articleRepo = articleRepo;
        }

        public async Task<Result<IQueryable<Entities.CollectionArticles>>> Handle(GetAllCollectionArticlesRequest request, CancellationToken cancellationToken)
        {
            var query = articleRepo.FindAll(x => x.IsActived != 2);

            if (request.IsActived.HasValue)
            {
                query = query.Where(x => x.IsActived == request.IsActived.Value);
            }

            return Result<IQueryable<Entities.CollectionArticles>>.Ok(query);
        }
    }
}