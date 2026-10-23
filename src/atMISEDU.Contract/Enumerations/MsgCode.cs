namespace atMISEDU.Contract.Enumerations
{
    public enum MsgCode
    {
        SUCCESS,
        ERR_INVALID,
        ERR_CONFLICT,
        ERR_NF_FIND_KEY,
        ERR_INTERNAL_SERVER,
        ERR_UNSUPPORTED_MEDIA_TYPE,
        ERR_NOT_FOUND,
        ERR_BAD_REQUEST,
        ERR_INVALID_FILE,
        ERR_FILE_TOO_LARGE,

        #region HUBS
        ERR_HUBS_HUBS_CHANNEL_INVALID,
        ERR_HUBS_HUBS_CHANNEL_ID_NOT_FOUND,
        #endregion

        #region CATALOG
        ERR_CATALOG_CATALOG_UNIT_INVALID,
        ERR_CATALOG_CATALOG_UNIT_ID_NOT_FOUND,
        #endregion

        #region CollectionArticles msg codes
        ERR_COLLECTION_ARTICLES_INVALID,
        ERR_COLLECTION_ARTICLES_ID_NOT_FOUND,
        #endregion

        #region CollectionTags msg codes
        ERR_COLLECTION_TAGS_INVALID,
        ERR_COLLECTION_TAGS_ID_NOT_FOUND,
        #endregion

        #region CollectionAwardCatalog msg codes
        ERR_COLLECTION_AWARD_CATALOG_INVALID,
        ERR_COLLECTION_AWARD_CATALOG_ID_NOT_FOUND,
        #endregion
    }
}