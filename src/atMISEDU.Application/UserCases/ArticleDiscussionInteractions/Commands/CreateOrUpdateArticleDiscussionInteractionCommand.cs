using System;
using System.Threading;
using System.Threading.Tasks;
using atMISEDU.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace atMISEDU.Application.UserCases.ArticleDiscussionInteractions.Commands
{
    public class CreateOrUpdateArticleDiscussionInteractionCommand : IRequest<Guid>
    {
        public Guid DiscussionId { get; set; }
        public Guid UserId { get; set; }
        public int InteractionType { get; set; }
    }

    public class CreateOrUpdateArticleDiscussionInteractionCommandHandler : IRequestHandler<CreateOrUpdateArticleDiscussionInteractionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrUpdateArticleDiscussionInteractionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOrUpdateArticleDiscussionInteractionCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.ArticleDiscussionInteractions
                .FirstOrDefaultAsync(x => x.DiscussionId == request.DiscussionId && x.UserId == request.UserId, cancellationToken);

            if (existing != null)
            {
                existing.InteractionType = request.InteractionType;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);
                return existing.Id;
            }

            var entity = new ArticleDiscussionInteraction
            {
                Id = Guid.NewGuid(),
                DiscussionId = request.DiscussionId,
                UserId = request.UserId,
                InteractionType = request.InteractionType,
                CreatedAt = DateTime.UtcNow
            };

            _context.ArticleDiscussionInteractions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}