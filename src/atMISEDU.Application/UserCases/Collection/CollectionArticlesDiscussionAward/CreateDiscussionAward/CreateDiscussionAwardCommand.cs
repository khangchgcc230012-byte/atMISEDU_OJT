using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.CreateDiscussionAward;
public record CreateDiscussionAwardCommand(Guid DiscussionId, Guid AwardId, Guid CreatedBy, bool? IsActived) : IRequest<CreateDiscussionAwardResponse>;
public record CreateDiscussionAwardResponse(Guid DaId, bool Success, string Message);
