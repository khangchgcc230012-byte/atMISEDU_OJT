using System;

namespace atMISEDU.Application.UserCases.ArticleInteractions.Queries
{
    public class ArticleInteractionDto
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
        public int InteractionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}