using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.DeleteAward;
public class DeleteAwardCommandHandler : IRequestHandler<DeleteAwardCommand, Unit>
{
    public async Task<Unit> Handle(DeleteAwardCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Unit.Value);
    }
}
