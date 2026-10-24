namespace atMISEDU.Domain.Constants.Collections
{
    public class CollectionTagsConst
    {
        #region Database defines
        public const string FIELD_ID = "keyTags";
        public const string FIELD_TAG_NAME = "tagsName";
        public const string FIELD_ICON = "tagsIcon";
        public const string FIELD_TAG_DESCRIPTION = "tagsDescription";
        public const string FIELD_TAG_STYLE = "tagsStyle";
        public const string FIELD_CREATED_BY = "createdBy";
        public const string FIELD_CREATED_DATE = "createdDate";
        public const string FIELD_IS_ACTIVED = "isActived";
        #endregion

        #region Max length defines
        public const int TAG_NAME_MAX_LENGTH = 128;
        public const int TAG_DESCRIPTION_MAX_LENGTH = 500;
        public const int TAG_COLOR_MAX_LENGTH = 32;
        #endregion
    }
}