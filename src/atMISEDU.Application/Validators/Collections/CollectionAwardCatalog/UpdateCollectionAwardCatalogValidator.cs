using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;
using atMISEDU.Domain.Constants.Collections;

namespace atMISEDU.Application.Validators.Collections.CollectionAwardCatalog
{
    public class UpdateCollectionAwardCatalogValidator : Validator<UpdateCollectionAwardCatalogRequest>
    {
        public UpdateCollectionAwardCatalogValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_AWARD_CATALOG_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.AwardName).MaxLength(CollectionAwardCatalogConst.AWARD_NAME_MAX_LENGTH);
            RuleFor(x => x.AwardDescription).MaxLength(CollectionAwardCatalogConst.AWARD_DESCRIPTION_MAX_LENGTH);
            RuleFor(x => x.AwardIcon).MaxLength(CollectionAwardCatalogConst.AWARD_ICON_MAX_LENGTH);
            RuleFor(x => x.AwardPoint).GreaterThan(0);
        }
    }
}