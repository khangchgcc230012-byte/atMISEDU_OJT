using atMISEDU.Application;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class DeleteArticleInteractionCommand : IRequest<bool>
{
    public Guid InteractionId { get; set; }
}

public class DeleteArticleInteractionCommandHandler : IRequestHandler<DeleteArticleInteractionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteArticleInteractionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteArticleInteractionCommand request, CancellationToken cancellationToken)
    {
        // Find the interaction by ID
        var interaction = await _context.ArticleInteractions.FindAsync(new object[] { request.InteractionId }, cancellationToken);

        if (interaction == null)
        {
            return false; // Return false if not found
        }

        // Remove the record from the database
        _context.ArticleInteractions.Remove(interaction);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}