using atMISEDU.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using atMISEDU.Domain.Entities;

namespace atMISEDU.Application.UserCases.ArticleInteractions.Commands { 
public class CreateArticleInteractionCommand : IRequest<Guid>
{
    public Guid ArticleId { get; set; }
    public int IntnType { get; set; }
    public Guid CreatedBy { get; set; }
    public bool IsActived { get; set; } = true;
}

public class CreateArticleInteractionCommandHandler : IRequestHandler<CreateArticleInteractionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateArticleInteractionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateArticleInteractionCommand request, CancellationToken cancellationToken)
    {
        // Check if the user has already interacted with this article
        var existingInteraction = await _context.ArticleInteractions
            .FirstOrDefaultAsync(x => x.ArticleId == request.ArticleId && x.CreatedBy == request.CreatedBy, cancellationToken);

        if (existingInteraction != null)
        {
            // Update IntnType if it already exists (do not insert a new row)
            existingInteraction.IntnType = request.IntnType;
            existingInteraction.IsActived = request.IsActived;
            await _context.SaveChangesAsync(cancellationToken);
            return existingInteraction.InteractionId;
        }

        // Create a new interaction if it does not exist
        var newInteraction = new ArticleInteraction
        {
            InteractionId = Guid.NewGuid(),
            ArticleId = request.ArticleId,
            IntnType = request.IntnType,
            CreatedBy = request.CreatedBy,
            IsActived = request.IsActived,
            CreatedDate = DateTime.UtcNow
        };

        _context.ArticleInteractions.Add(newInteraction);
        await _context.SaveChangesAsync(cancellationToken);

        return newInteraction.InteractionId;
    }
}
}