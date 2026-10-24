using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;
using atMISEDU.Domain.Constants.Collections;

namespace atMISEDU.Application.Validators.Collections.CollectionArticles
{
    public class UpdateCollectionArticlesValidator : Validator<UpdateCollectionArticlesRequest>
    {
        public UpdateCollectionArticlesValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_ARTICLES_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.ArticleTitle).MaxLength(CollectionArticlesConst.ARTICLE_TITLE_MAX_LENGTH);
            RuleFor(x => x.ArticleAbstract).MaxLength(CollectionArticlesConst.ARTICLE_ABSTRACT_MAX_LENGTH);
            RuleFor(x => x.ArticleThumbnail).MaxLength(CollectionArticlesConst.ARTICLE_THUMBNAIL_MAX_LENGTH);
        }
    }
}