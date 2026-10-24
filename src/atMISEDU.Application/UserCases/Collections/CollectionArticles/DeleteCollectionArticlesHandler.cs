using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionArticles
{
    public class DeleteCollectionArticlesHandler : IRequestHandler<DeleteCollectionArticlesRequest, Result<object>>
    {
        private readonly ICollectionArticlesSqlRepository articleRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public DeleteCollectionArticlesHandler(ICollectionArticlesSqlRepository articleRepo, ISqlUnitOfWork unitOfWork)
        {
            this.articleRepo = articleRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(DeleteCollectionArticlesRequest request, CancellationToken cancellationToken)
        {
            var article = await articleRepo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (article == null || article.IsActived == 2)
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionArticles), MsgCode.ERR_COLLECTION_ARTICLES_ID_NOT_FOUND);

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                article.IsActived = 2; // Xóa mềm (IsActived = 2)
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok(); // DELETE chỉ trả về thành công (data = null)
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}