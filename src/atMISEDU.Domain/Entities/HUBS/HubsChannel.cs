using atMISEDU.Domain.Abstractions.Entities;

namespace atMISEDU.Domain.Entities.HUBS
{
    public class HubsChannel : Entity<int>
    {
        public string CnName { get; set; } = string.Empty;
        public string CnUrl { get; set; } = string.Empty;
        public string CnIcon { get; set; } = string.Empty;
        public string CnStyle { get; set; } = string.Empty;
        public int CnOrder { get; set; }
        public int IsActived { get; set; }
    }
}