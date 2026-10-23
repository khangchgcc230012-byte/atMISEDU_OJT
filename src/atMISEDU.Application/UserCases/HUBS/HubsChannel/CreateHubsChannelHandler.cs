using atMISEDU.Application.Requests.HUBS.HubsChannel;
using atMISEDU.Application.Validators.HUBS.HubsChannel;
using atMISEDU.Contract.DependencyInjection.Extensions;
using atMISEDU.Contract.Shared;
using atMISEDU.Domain.Abstractions.Repositories.Sql.Base;
using atMISEDU.Domain.Abstractions.Repositories.Sql.HUBS;
using MediatR;
using Entities = atMISEDU.Domain.Entities.HUBS;

namespace atMISEDU.Application.UserCases.HUBS.HubsChannel
{
    public class CreateHubsChannelHandler : IRequestHandler<CreateHubsChannelRequest, Result<object>>
    {
        private readonly IHubsChannelSqlRepository hubsChannelRepo;
        private readonly ISqlUnitOfWork unitOfWork;

        public CreateHubsChannelHandler(IHubsChannelSqlRepository hubsChannelRepo, ISqlUnitOfWork unitOfWork)
        {
            this.hubsChannelRepo = hubsChannelRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<object>> Handle(CreateHubsChannelRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateHubsChannelValidator();
            validator.ValidateAndThrow(request);
            
            // Map request sang Entity
            var hubsChannel = request.MapTo<Entities.HubsChannel>();

            using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {

                hubsChannelRepo.Add(hubsChannel!);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                transaction.Commit();
                return Result<object>.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}