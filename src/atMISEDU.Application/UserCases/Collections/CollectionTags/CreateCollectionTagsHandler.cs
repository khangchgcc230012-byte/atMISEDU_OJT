using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Application.Validators.Collections.CollectionTags;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionTags
{
    public class CreateCollectionTagsHandler : IRequestHandler<CreateCollectionTagsRequest, Result<object>>
    {
        private readonly ICollectionTagsSqlRepository tagRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public CreateCollectionTagsHandler(ICollectionTagsSqlRepository tagRepo, ISqlUnitOfWork unitOfWork)
        {
            this.tagRepo = tagRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(CreateCollectionTagsRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCollectionTagsValidator();
            validator.ValidateAndThrow(request);

            var tag = request.MapTo<Entities.CollectionTags>();
            tag.CreatedDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                tagRepo.Add(tag);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok(new { tagId = tag.Id });
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}