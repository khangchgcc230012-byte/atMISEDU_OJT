using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionAwardCatalog
{
    public class GetAllCollectionAwardCatalogHandler : IRequestHandler<GetAllCollectionAwardCatalogRequest, Result<IQueryable<Entities.CollectionAwardCatalog>>>
    {
        private readonly ICollectionAwardCatalogSqlRepository awardRepo;

        public GetAllCollectionAwardCatalogHandler(ICollectionAwardCatalogSqlRepository awardRepo)
        {
            this.awardRepo = awardRepo;
        }

        public async Task<Result<IQueryable<Entities.CollectionAwardCatalog>>> Handle(GetAllCollectionAwardCatalogRequest request, CancellationToken cancellationToken)
        {
            var query = awardRepo.FindAll(x => x.IsActived != 2);

            if (request.IsActived.HasValue)
            {
                query = query.Where(x => x.IsActived == request.IsActived.Value);
            }

            return Result<IQueryable<Entities.CollectionAwardCatalog>>.Ok(query);
        }
    }
}