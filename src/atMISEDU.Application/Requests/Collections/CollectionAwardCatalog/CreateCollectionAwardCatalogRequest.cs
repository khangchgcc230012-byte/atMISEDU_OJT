using atMISEDU.Contract.Abstractions;

namespace atMISEDU.Application.Requests.Collections.CollectionAwardCatalog
{
    public class CreateCollectionAwardCatalogRequest : ICommand
    {
        public string? AwardName { get; set; }
        public string? AwardDescription { get; set; }
        public string? AwardIcon { get; set; }
        public int? AwardPoint { get; set; }
        public int? CreatedBy { get; set; }
        public byte? IsActived { get; set; } = 1;
    }
}