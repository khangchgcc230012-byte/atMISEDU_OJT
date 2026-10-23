using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Entities.HUBS;

namespace atMISEDU.Domain.Abstractions.Repositories.Sql.HUBS
{
    public interface IHubsChannelSqlRepository : IGenericSqlRepository<HubsChannel, int>
    {
    }
}