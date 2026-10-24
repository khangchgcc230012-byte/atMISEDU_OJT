using System;
using atMISEDU.Domain.Abstractions.Entities;

namespace atMISEDU.Domain.Entities
{
    public class ArticleVote : Entity<Guid>
    {
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
        public int VoteValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}