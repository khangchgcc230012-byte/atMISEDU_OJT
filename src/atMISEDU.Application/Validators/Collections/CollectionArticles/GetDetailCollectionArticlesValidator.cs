using atMISEDU.Application.Requests.Collections.CollectionArticles;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;

namespace atMISEDU.Application.Validators.Collections.CollectionArticles
{
    public class GetDetailCollectionArticlesValidator : Validator<GetDetailCollectionArticlesRequest>
    {
        public GetDetailCollectionArticlesValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_ARTICLES_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}