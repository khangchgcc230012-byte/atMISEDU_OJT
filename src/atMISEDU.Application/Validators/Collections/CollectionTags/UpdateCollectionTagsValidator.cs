using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;
using atMISEDU.Domain.Constants.Collections;

namespace atMISEDU.Application.Validators.Collections.CollectionTags
{
    public class UpdateCollectionTagsValidator : Validator<UpdateCollectionTagsRequest>
    {
        public UpdateCollectionTagsValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_TAGS_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.TagName).MaxLength(CollectionTagsConst.TAG_NAME_MAX_LENGTH);
            RuleFor(x => x.TagSlug).MaxLength(CollectionTagsConst.TAG_SLUG_MAX_LENGTH);
            RuleFor(x => x.TagDescription).MaxLength(CollectionTagsConst.TAG_DESCRIPTION_MAX_LENGTH);
            RuleFor(x => x.TagColor).MaxLength(CollectionTagsConst.TAG_COLOR_MAX_LENGTH);
        }
    }
}