using MediatR;

namespace atMISEDU.Application.UserCases.Collection.Catalog.CreateCatalog;

public record CreateCatalogCommand(
    string Name,
    string? Description
) : IRequest<CreateCatalogResponse>;
