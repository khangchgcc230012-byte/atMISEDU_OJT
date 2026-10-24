using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Application.Validators.Collections.CollectionArticles;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionArticles
{
    public class CreateCollectionArticlesHandler : IRequestHandler<CreateCollectionArticlesRequest, Result<object>>
    {
        private readonly ICollectionArticlesSqlRepository articleRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public CreateCollectionArticlesHandler(ICollectionArticlesSqlRepository articleRepo, ISqlUnitOfWork unitOfWork)
        {
            this.articleRepo = articleRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(CreateCollectionArticlesRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateCollectionArticlesValidator();
            validator.ValidateAndThrow(request);

            var article = request.MapTo<Entities.CollectionArticles>();
            article.CreatedDate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(); // BE tự gán Unix UTC time

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                articleRepo.Add(article);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();

                return Result<object>.Ok(new { articleId = article.Id }); // POST trả về object chứa articleId
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}