using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.DeleteAward;
public record DeleteAwardCommand(Guid Id) : IRequest<Unit>;
