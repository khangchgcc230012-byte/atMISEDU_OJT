using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionTags
{
    public class GetAllCollectionTagsHandler : IRequestHandler<GetAllCollectionTagsRequest, Result<IQueryable<Entities.CollectionTags>>>
    {
        private readonly ICollectionTagsSqlRepository tagRepo;

        public GetAllCollectionTagsHandler(ICollectionTagsSqlRepository tagRepo)
        {
            this.tagRepo = tagRepo;
        }

        public async Task<Result<IQueryable<Entities.CollectionTags>>> Handle(GetAllCollectionTagsRequest request, CancellationToken cancellationToken)
        {
            var query = tagRepo.FindAll(x => x.IsActived != 2);

            if (request.IsActived.HasValue)
            {
                query = query.Where(x => x.IsActived == request.IsActived.Value);
            }

            return Result<IQueryable<Entities.CollectionTags>>.Ok(query);
        }
    }
}