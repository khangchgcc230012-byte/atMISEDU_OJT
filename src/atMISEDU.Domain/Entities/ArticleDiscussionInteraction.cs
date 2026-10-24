using System;
using atMISEDU.Domain.Abstractions.Entities;

namespace atMISEDU.Domain.Entities
{
    public class ArticleDiscussionInteraction : Entity<Guid>
    {
        public Guid DiscussionId { get; set; }
        public Guid UserId { get; set; }
        public int InteractionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}