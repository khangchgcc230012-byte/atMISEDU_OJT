using atMISEDU.Application.Requests.Collections.CollectionTags;
using atMISEDU.Contract.Enumerations;
using atMISEDU.Contract.Exceptions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Collections;
using MediatR;
using Entities = atMISEDU.Domain.Entities.Collections;

namespace atMISEDU.Application.UserCases.Collections.CollectionTags
{
    public class GetDetailCollectionTagsHandler : IRequestHandler<GetDetailCollectionTagsRequest, Result<Entities.CollectionTags>>
    {
        private readonly ICollectionTagsSqlRepository tagRepo;

        public GetDetailCollectionTagsHandler(ICollectionTagsSqlRepository tagRepo)
        {
            this.tagRepo = tagRepo;
        }

        public async Task<Result<Entities.CollectionTags>> Handle(GetDetailCollectionTagsRequest request, CancellationToken cancellationToken)
        {
            var tag = tagRepo.FindAll(x => x.Id.Equals(request.Id) && x.IsActived != 2).FirstOrDefault();
            if (tag == null)
            {
                CustomException.ThrowNotFoundException(typeof(Entities.CollectionTags), MsgCode.ERR_COLLECTION_TAGS_ID_NOT_FOUND);
            }
            return tag;
        }
    }
}