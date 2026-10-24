using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Domain.Abstractions.Repositories.Sql.Collections
{
    public interface ICollectionTagsSqlRepository : IGenericSqlRepository<CollectionTags, int>
    {
    }
}