using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.UpdateAward;
public class UpdateAwardCommandHandler : IRequestHandler<UpdateAwardCommand, Unit>
{
    public async Task<Unit> Handle(UpdateAwardCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Unit.Value);
    }
}
