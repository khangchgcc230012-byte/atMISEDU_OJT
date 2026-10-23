using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Application.Validators.Collections.CollectionAwardCatalog;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionAwardCatalog
{
    public class CreateCollectionAwardCatalogHandler : IRequestHandler<CreateCollectionAwardCatalogRequest, Result<object>>
    {
        private readonly ICollectionAwardCatalogSqlRepository awardRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public CreateCollectionAwardCatalogHandler(ICollectionAwardCatalogSqlRepository awardRepo, ISqlUnitOfWork unitOfWork)
        {
            this.awardRepo = awardRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(CreateCollectionAwardCatalogRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCollectionAwardCatalogValidator();
            validator.ValidateAndThrow(request);

            var entity = request.MapTo<Entities.CollectionAwardCatalog>();
            entity.CreatedDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                awardRepo.Add(entity);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok(new { awardId = entity.Id });
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}