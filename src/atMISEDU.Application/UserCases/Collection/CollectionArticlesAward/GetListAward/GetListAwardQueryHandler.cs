using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.GetListAward;
public class GetListAwardQueryHandler : IRequestHandler<GetListAwardQuery, IEnumerable<object>>
{
    public async Task<IEnumerable<object>> Handle(GetListAwardQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<object>());
    }
}
