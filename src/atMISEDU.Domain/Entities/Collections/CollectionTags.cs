using atMISEDU.Domain.Abstractions.Aggregates;

namespace atMISEDU.Domain.Entities.Collections
{
    public class CollectionTags : AggregateRoot<int>
    {
        public string TagName { get; set; }
        public string TagSlug { get; set; }
        public string? TagDescription { get; set; }
        public string? TagColor { get; set; }
        public int CreatedBy { get; set; }
        public int CreatedDate { get; set; }
        public byte IsActived { get; set; }
    }
}