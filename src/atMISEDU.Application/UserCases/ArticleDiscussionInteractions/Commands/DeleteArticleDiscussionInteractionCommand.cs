using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace atMISEDU.Application.UserCases.ArticleDiscussionInteractions.Commands
{
    public record DeleteArticleDiscussionInteractionCommand(Guid DiscussionId, Guid UserId) : IRequest<bool>;

    public class DeleteArticleDiscussionInteractionCommandHandler : IRequestHandler<DeleteArticleDiscussionInteractionCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteArticleDiscussionInteractionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteArticleDiscussionInteractionCommand request, CancellationToken cancellationToken)
        {
            var existing = await _context.ArticleDiscussionInteractions
                .FirstOrDefaultAsync(x => x.DiscussionId == request.DiscussionId && x.UserId == request.UserId, cancellationToken);

            if (existing == null) return false;

            _context.ArticleDiscussionInteractions.Remove(existing);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}