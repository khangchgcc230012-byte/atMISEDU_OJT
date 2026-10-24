using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionAwardCatalog
{
    public class GetDetailCollectionAwardCatalogHandler : IRequestHandler<GetDetailCollectionAwardCatalogRequest, Result<Entities.CollectionAwardCatalog>>
    {
        private readonly ICollectionAwardCatalogSqlRepository awardRepo;

        public GetDetailCollectionAwardCatalogHandler(ICollectionAwardCatalogSqlRepository awardRepo)
        {
            this.awardRepo = awardRepo;
        }

        public async Task<Result<Entities.CollectionAwardCatalog>> Handle(GetDetailCollectionAwardCatalogRequest request, CancellationToken cancellationToken)
        {
            var entity = awardRepo.FindAll(x => x.Id.Equals(request.Id) && x.IsActived != 2).FirstOrDefault();
            if (entity == null)
            {
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionAwardCatalog), MsgCode.ERR_COLLECTION_AWARD_CATALOG_ID_NOT_FOUND);
            }
            return entity;
        }
    }
}