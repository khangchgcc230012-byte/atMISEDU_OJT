using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionArticles
{
    public class UpdateCollectionArticlesHandler : IRequestHandler<UpdateCollectionArticlesRequest, Result<object>>
    {
        private readonly ICollectionArticlesSqlRepository articleRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public UpdateCollectionArticlesHandler(ICollectionArticlesSqlRepository articleRepo, ISqlUnitOfWork unitOfWork)
        {
            this.articleRepo = articleRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateCollectionArticlesRequest request, CancellationToken cancellationToken)
        {
            var article = await articleRepo.FindByIdAsync((int)request.Id, true, cancellationToken);
            if (article == null || article.IsActived == 2)
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionArticles), MsgCode.ERR_COLLECTION_ARTICLES_ID_NOT_FOUND);

            request.MapTo(article, true); // Giữ nguyên các thuộc tính null

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                articleRepo.Update(article);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok(); // PUT chỉ trả về thành công (data = null)
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}