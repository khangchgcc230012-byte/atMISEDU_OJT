using atMISEDU.Application;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class UpdateArticleInteractionCommand : IRequest<bool>
{
    public Guid InteractionId { get; set; }
    public int IntnType { get; set; }
    public bool IsActived { get; set; }
}

public class UpdateArticleInteractionCommandHandler : IRequestHandler<UpdateArticleInteractionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateArticleInteractionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateArticleInteractionCommand request, CancellationToken cancellationToken)
    {
        // Find the interaction by ID
        var interaction = await _context.ArticleInteractions.FindAsync(new object[] { request.InteractionId }, cancellationToken);

        if (interaction == null)
        {
            return false; // Return false if not found
        }

        // Update properties
        interaction.IntnType = request.IntnType;
        interaction.IsActived = request.IsActived;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}