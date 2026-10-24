using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionAwardCatalog
{
    public class UpdateCollectionAwardCatalogHandler : IRequestHandler<UpdateCollectionAwardCatalogRequest, Result<object>>
    {
        private readonly ICollectionAwardCatalogSqlRepository awardRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public UpdateCollectionAwardCatalogHandler(ICollectionAwardCatalogSqlRepository awardRepo, ISqlUnitOfWork unitOfWork)
        {
            this.awardRepo = awardRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateCollectionAwardCatalogRequest request, CancellationToken cancellationToken)
        {
            var entity = await awardRepo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (entity == null || entity.IsActived == 2)
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionAwardCatalog), MsgCode.ERR_COLLECTION_AWARD_CATALOG_ID_NOT_FOUND);

            request.MapTo(entity, true);

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                awardRepo.Update(entity);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}