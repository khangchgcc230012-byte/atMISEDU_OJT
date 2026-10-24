using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.GetDiscussionAwardById;
public record GetDiscussionAwardByIdQuery(Guid Id) : IRequest<object>;
