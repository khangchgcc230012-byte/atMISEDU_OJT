using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.DeleteDiscussionAward;
public record DeleteDiscussionAwardCommand(Guid Id) : IRequest<Unit>;
