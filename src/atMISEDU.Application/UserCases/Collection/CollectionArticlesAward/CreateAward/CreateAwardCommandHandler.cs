using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.CreateAward;
public class CreateAwardCommandHandler : IRequestHandler<CreateAwardCommand, CreateAwardResponse>
{
    public async Task<CreateAwardResponse> Handle(CreateAwardCommand request, CancellationToken cancellationToken)
    {
        var awId = Guid.NewGuid();
        return await Task.FromResult(new CreateAwardResponse(awId, true, "Award created successfully!"));
    }
}
