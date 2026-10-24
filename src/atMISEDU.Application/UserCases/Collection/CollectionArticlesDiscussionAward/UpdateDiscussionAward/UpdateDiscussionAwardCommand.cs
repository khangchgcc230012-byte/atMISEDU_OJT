using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.UpdateDiscussionAward;
public record UpdateDiscussionAwardCommand(Guid Id, Guid AwardId, bool? IsActived) : IRequest<Unit>;
