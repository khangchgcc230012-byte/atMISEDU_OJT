using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.GetAwardById;
public record GetAwardByIdQuery(Guid Id) : IRequest<object>;
