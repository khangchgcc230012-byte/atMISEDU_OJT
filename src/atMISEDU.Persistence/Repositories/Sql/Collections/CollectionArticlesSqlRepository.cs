using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using atMISEDU.Domain.Entities.Collections;
using atMISEDU.Persistence.Repositories.Sql.Base;

namespace atMISEDU.Persistence.Repositories.Sql.Collections
{
	public class CollectionArticlesSqlRepository(ApplicationDbContext context)
		: GenericSqlRepository<CollectionArticles, int>(context), ICollectionArticlesSqlRepository
	{
	}
}