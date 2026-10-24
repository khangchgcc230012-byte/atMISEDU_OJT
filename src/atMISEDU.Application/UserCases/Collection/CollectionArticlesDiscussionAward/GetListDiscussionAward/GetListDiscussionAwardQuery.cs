using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.GetListDiscussionAward;
public record GetListDiscussionAwardQuery(Guid? DiscussionId, bool? IsActived) : IRequest<IEnumerable<object>>;
