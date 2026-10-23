using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;

namespace atMISEDU.Application.Validators.Collections.CollectionTags
{
    public class GetDetailCollectionTagsValidator : Validator<GetDetailCollectionTagsRequest>
    {
        public GetDetailCollectionTagsValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_TAGS_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
        }
    }
}