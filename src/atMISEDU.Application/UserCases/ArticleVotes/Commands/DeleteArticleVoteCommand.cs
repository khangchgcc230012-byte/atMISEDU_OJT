using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace atMISEDU.Application.UserCases.ArticleVotes.Commands
{
    public record DeleteArticleVoteCommand(
        Guid ArticleId,
        Guid UserId
    ) : IRequest<bool>;

    public class DeleteArticleVoteCommandHandler
        : IRequestHandler<DeleteArticleVoteCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteArticleVoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteArticleVoteCommand request, CancellationToken cancellationToken)
        {
            var existingVote = await _context.ArticleVotes
                .FirstOrDefaultAsync(x => x.ArticleId == request.ArticleId && x.UserId == request.UserId, cancellationToken);

            if (existingVote == null)
            {
                return false;
            }

            _context.ArticleVotes.Remove(existingVote);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}