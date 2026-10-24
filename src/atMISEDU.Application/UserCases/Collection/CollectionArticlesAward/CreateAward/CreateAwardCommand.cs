using MediatR;
namespace atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.CreateAward;
public record CreateAwardCommand(Guid ArticleId, Guid AwardId, Guid CreatedBy, bool? IsActived) : IRequest<CreateAwardResponse>;
public record CreateAwardResponse(Guid AwId, bool Success, string Message);
