using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.DeleteDiscussionAward;
public class DeleteDiscussionAwardCommandHandler : IRequestHandler<DeleteDiscussionAwardCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDiscussionAwardCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(Unit.Value);
    }
}
