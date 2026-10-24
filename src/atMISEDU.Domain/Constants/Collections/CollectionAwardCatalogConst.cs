namespace atMISEDU.Domain.Constants.Collections
{
    public class CollectionAwardCatalogConst
    {
        #region Database defines
        public const string FIELD_ID = "awardId";
        public const string FIELD_AWARD_NAME = "awardName";
        public const string FIELD_AWARD_DESCRIPTION = "awardDescription";
        public const string FIELD_AWARD_ICON = "awardIcon";
        public const string FIELD_AWARD_POINT = "awardPoint";
        public const string FIELD_CREATED_BY = "createdBy";
        public const string FIELD_CREATED_DATE = "createdDate";
        public const string FIELD_IS_ACTIVED = "isActived";
        #endregion

        #region Max length defines
        public const int AWARD_NAME_MAX_LENGTH = 128;
        public const int AWARD_DESCRIPTION_MAX_LENGTH = 500;
        public const int AWARD_ICON_MAX_LENGTH = 256;
        #endregion
    }
}