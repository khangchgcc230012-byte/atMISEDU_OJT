using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.GetListAward;
public record GetListAwardQuery(Guid? ArticleId, bool? IsActived) : IRequest<IEnumerable<object>>;
