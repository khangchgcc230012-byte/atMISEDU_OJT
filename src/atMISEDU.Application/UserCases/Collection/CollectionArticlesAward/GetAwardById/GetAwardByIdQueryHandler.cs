using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.GetAwardById;
public class GetAwardByIdQueryHandler : IRequestHandler<GetAwardByIdQuery, object>
{
    public async Task<object> Handle(GetAwardByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new { Id = request.Id, Message = "Award detail mock data" });
    }
}
