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
        ERR_CATALOG_CATALOG_UNIT_ID_NOT_FOUND
        #endregion
    }
}