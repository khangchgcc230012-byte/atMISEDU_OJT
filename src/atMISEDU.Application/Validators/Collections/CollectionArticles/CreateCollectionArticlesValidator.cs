using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;
using atMISEDU.Domain.Constants.Collections;

namespace atMISEDU.Application.Validators.Collections.CollectionArticles
{
    public class CreateCollectionArticlesValidator : Validator<CreateCollectionArticlesRequest>
    {
        public CreateCollectionArticlesValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_ARTICLES_INVALID);
            RuleFor(x => x.ArticleTitle).NotNull().MaxLength(CollectionArticlesConst.ARTICLE_TITLE_MAX_LENGTH);
            RuleFor(x => x.ArticleAbstract).MaxLength(CollectionArticlesConst.ARTICLE_ABSTRACT_MAX_LENGTH);
            RuleFor(x => x.ArticleThumbnail).MaxLength(CollectionArticlesConst.ARTICLE_THUMBNAIL_MAX_LENGTH);
            RuleFor(x => x.ArticlePublishedDate).NotNull();
            RuleFor(x => x.ArticleIPAddress).NotNull().MaxLength(CollectionArticlesConst.ARTICLE_IP_ADDRESS_MAX_LENGTH);
            RuleFor(x => x.ArticleBrowser).NotNull().MaxLength(CollectionArticlesConst.ARTICLE_BROWSER_MAX_LENGTH);
            RuleFor(x => x.ArticleOstype).MaxLength(CollectionArticlesConst.ARTICLE_OSTYPE_MAX_LENGTH);
            RuleFor(x => x.CreatedBy).NotNull().GreaterThan(0);
        }
    }
}