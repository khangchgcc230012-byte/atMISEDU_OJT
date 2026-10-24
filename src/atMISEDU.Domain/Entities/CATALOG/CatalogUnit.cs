using atMISEDU.Domain.Abstractions.Entities;

namespace atMISEDU.Domain.Entities.CATALOG
{
    public class CatalogUnit : Entity<int>
    {
        public int CugID { get; set; }
        public string UnitCode { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public string UnitEnglish { get; set; } = string.Empty;
        public int IsActived { get; set; }
    }
}