using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.UpdateDiscussionAward;
public class UpdateDiscussionAwardCommandHandler : IRequestHandler<UpdateDiscussionAwardCommand, Unit>
{
    public async Task<Unit> Handle(UpdateDiscussionAwardCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Unit.Value);
    }
}
