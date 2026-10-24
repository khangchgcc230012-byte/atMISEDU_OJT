namespace atMISEDU.Application.UserCases.Collection.Catalog.CreateCatalog;

public record CreateCatalogResponse(
    Guid Id,
    string Name,
    string? Description,
    bool Success,
    string Message
);
