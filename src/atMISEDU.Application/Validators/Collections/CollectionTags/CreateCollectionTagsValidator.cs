using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Validators;
using atMISEDU.Domain.Constants.Collections;

namespace atMISEDU.Application.Validators.Collections.CollectionTags
{
    public class CreateCollectionTagsValidator : Validator<CreateCollectionTagsRequest>
    {
        public CreateCollectionTagsValidator()
        {
            WithValidator(MsgCode.ERR_COLLECTION_TAGS_INVALID);
            RuleFor(x => x.TagName).NotNull().MaxLength(CollectionTagsConst.TAG_NAME_MAX_LENGTH);
            RuleFor(x => x.TagDescription).MaxLength(CollectionTagsConst.TAG_DESCRIPTION_MAX_LENGTH);
            RuleFor(x => x.TagColor).MaxLength(CollectionTagsConst.TAG_COLOR_MAX_LENGTH);
            RuleFor(x => x.CreatedBy).NotNull().GreaterThan(0);
        }
    }
}