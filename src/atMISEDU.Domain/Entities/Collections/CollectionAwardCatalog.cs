using atMISEDU.Domain.Abstractions.Aggregates;

namespace atMISEDU.Domain.Entities.Collections
{
    public class CollectionAwardCatalog : AggregateRoot<int>
    {
        public string? AwardName { get; set; }
        public string? AwardDescription { get; set; }
        public string? AwardIcon { get; set; }
        public int AwardPoint { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedDate { get; set; }
        public byte IsActived { get; set; }
    }
}