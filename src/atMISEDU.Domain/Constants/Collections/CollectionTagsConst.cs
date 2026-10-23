namespace atMISEDU.Domain.Constants.Collections
{
    public class CollectionTagsConst
    {
        #region Database defines
        public const string FIELD_ID = "tagId";
        public const string FIELD_TAG_NAME = "tagName";
        public const string FIELD_TAG_SLUG = "tagSlug";
        public const string FIELD_TAG_DESCRIPTION = "tagDescription";
        public const string FIELD_TAG_COLOR = "tagColor";
        public const string FIELD_CREATED_BY = "createdBy";
        public const string FIELD_CREATED_DATE = "createdDate";
        public const string FIELD_IS_ACTIVED = "isActived";
        #endregion

        #region Max length defines
        public const int TAG_NAME_MAX_LENGTH = 128;
        public const int TAG_SLUG_MAX_LENGTH = 128;
        public const int TAG_DESCRIPTION_MAX_LENGTH = 500;
        public const int TAG_COLOR_MAX_LENGTH = 32;
        #endregion
    }
}