using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using atMISEDU.Domain.Entities;

namespace atMISEDU.Application.UserCases.ArticleInteractions.Queries
{
    public record GetArticleInteractionQuery(Guid ArticleId, Guid UserId) : IRequest<ArticleInteractionDto?>;

    public class GetArticleInteractionQueryHandler : IRequestHandler<GetArticleInteractionQuery, ArticleInteractionDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetArticleInteractionQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ArticleInteractionDto?> Handle(GetArticleInteractionQuery request, CancellationToken cancellationToken)
        {
            return await _context.ArticleInteractions
                .AsNoTracking()
                .Where(x => x.ArticleId == request.ArticleId && (x.UserId == request.UserId || x.CreatedBy == request.UserId))
                .Select(x => new ArticleInteractionDto
                {
                    Id = x.Id != Guid.Empty ? x.Id : x.InteractionId,
                    ArticleId = x.ArticleId,
                    UserId = x.UserId != Guid.Empty ? x.UserId : x.CreatedBy,
                    InteractionType = x.InteractionType != 0 ? x.InteractionType : x.IntnType
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}