using atMISEDU.Domain.Abstractions.Entities;

namespace atMISEDU.Domain.Abstractions.Aggregates
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
    }
}