using atMISEDU.Application.UserCases.Collection.Catalog.CreateCatalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDUatMISEDUAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly ISender _mediator;

    public CatalogController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCatalog([FromBody] CreateCatalogCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
