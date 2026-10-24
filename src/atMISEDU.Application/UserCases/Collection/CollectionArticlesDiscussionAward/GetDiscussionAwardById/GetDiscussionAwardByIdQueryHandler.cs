using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.GetDiscussionAwardById;
public class GetDiscussionAwardByIdQueryHandler : IRequestHandler<GetDiscussionAwardByIdQuery, object>
{
    public async Task<object> Handle(GetDiscussionAwardByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new { Id = request.Id, Message = "Discussion Award detail mock data" });
    }
}
