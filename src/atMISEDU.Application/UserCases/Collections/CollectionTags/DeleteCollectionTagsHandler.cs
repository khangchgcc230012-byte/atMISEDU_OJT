using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionTags
{
    public class DeleteCollectionTagsHandler : IRequestHandler<DeleteCollectionTagsRequest, Result<object>>
    {
        private readonly ICollectionTagsSqlRepository tagRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public DeleteCollectionTagsHandler(ICollectionTagsSqlRepository tagRepo, ISqlUnitOfWork unitOfWork)
        {
            this.tagRepo = tagRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteCollectionTagsRequest request, CancellationToken cancellationToken)
        {
            var tag = await tagRepo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (tag == null || tag.IsActived == 2)
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionTags), MsgCode.ERR_COLLECTION_TAGS_ID_NOT_FOUND);

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                tag.IsActived = 2; // Xóa mềm
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