using System;
using atMISEDU.Domain.Abstractions.Entities;

namespace atMISEDU.Domain.Entities
{
    public class ArticleInteraction : Entity<Guid>
    {
        public Guid InteractionId { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
        public Guid CreatedBy { get; set; }
        public int IntnType { get; set; }
        public int InteractionType { get; set; }
        public bool IsActived { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}