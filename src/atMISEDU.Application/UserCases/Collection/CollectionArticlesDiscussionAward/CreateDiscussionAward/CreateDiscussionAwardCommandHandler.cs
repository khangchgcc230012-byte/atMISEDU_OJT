using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.CreateDiscussionAward;
public class CreateDiscussionAwardCommandHandler : IRequestHandler<CreateDiscussionAwardCommand, CreateDiscussionAwardResponse>
{
    public async Task<CreateDiscussionAwardResponse> Handle(CreateDiscussionAwardCommand request, CancellationToken cancellationToken)
    {
        var daId = Guid.NewGuid();
        return await Task.FromResult(new CreateDiscussionAwardResponse(daId, true, "Discussion Award created successfully!"));
    }
}
