using System;
using System.Threading;
using System.Threading.Tasks;
using atMISEDU.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace atMISEDU.Application.UserCases.ArticleVotes.Commands
{
    public record CreateOrUpdateArticleVoteCommand(
        Guid ArticleId,
        Guid UserId,
        int VoteValue
    ) : IRequest<Guid>;

    public class CreateOrUpdateArticleVoteCommandHandler
        : IRequestHandler<CreateOrUpdateArticleVoteCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrUpdateArticleVoteCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateOrUpdateArticleVoteCommand request, CancellationToken cancellationToken)
        {
            var existingVote = await _context.ArticleVotes
                .FirstOrDefaultAsync(x => x.ArticleId == request.ArticleId && x.UserId == request.UserId, cancellationToken);

            if (existingVote != null)
            {
                existingVote.VoteValue = request.VoteValue;
                existingVote.UpdatedAt = DateTime.UtcNow;
                _context.ArticleVotes.Update(existingVote);
                await _context.SaveChangesAsync(cancellationToken);
                return existingVote.Id;
            }

            var newVote = new ArticleVote
            {
                Id = Guid.NewGuid(),
                ArticleId = request.ArticleId,
                UserId = request.UserId,
                VoteValue = request.VoteValue,
                CreatedAt = DateTime.UtcNow
            };

            await _context.ArticleVotes.AddAsync(newVote, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newVote.Id;
        }
    }
}