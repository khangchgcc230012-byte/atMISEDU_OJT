using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;

namespace atMISEDU.Application.Validators.Collections.CollectionAwardCatalog
{
    public class GetDetailCollectionAwardCatalogValidator : Validator<GetDetailCollectionAwardCatalogRequest>
    {
        public GetDetailCollectionAwardCatalogValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_AWARD_CATALOG_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}