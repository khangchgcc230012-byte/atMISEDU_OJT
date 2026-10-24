using MediatR;

namespace atMISEDU.Application.UserCases.Collection.Catalog.CreateCatalog;

public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, CreateCatalogResponse>
{
    public CreateCatalogCommandHandler()
    {
    }

    public async Task<CreateCatalogResponse> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
    {
        var catalogId = Guid.NewGuid();

        return await Task.FromResult(new CreateCatalogResponse(
            Id: catalogId,
            Name: request.Name,
            Description: request.Description,
            Success: true,
            Message: "Catalog created successfully!"
        ));
    }
}
