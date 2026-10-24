using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.UpdateAward;
public record UpdateAwardCommand(Guid Id, Guid AwardId, bool? IsActived) : IRequest<Unit>;
