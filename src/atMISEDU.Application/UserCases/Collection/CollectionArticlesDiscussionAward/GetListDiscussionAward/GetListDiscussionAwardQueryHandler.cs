using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.GetListDiscussionAward;
public class GetListDiscussionAwardQueryHandler : IRequestHandler<GetListDiscussionAwardQuery, IEnumerable<object>>
{
    public async Task<IEnumerable<object>> Handle(GetListDiscussionAwardQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<object>());
    }
}
