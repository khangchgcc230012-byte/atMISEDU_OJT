using atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.CreateAward;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.DeleteAward;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.GetAwardById;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.GetListAward;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesAward.UpdateAward;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDUatMISEDUAPI.Controllers;

[ApiController]
[Route("v1/collections/CollectionArticlesAward")]
public class CollectionArticlesAwardController : ControllerBase
{
    private readonly ISender _mediator;
    public CollectionArticlesAwardController(ISender mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAwardCommand command) => Ok(await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAwardCommand command)
    {
        var cmd = new UpdateAwardCommand(id, command.AwardId, command.IsActived);
        await _mediator.Send(cmd);
        return Ok(null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteAwardCommand(id));
        return Ok(null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await _mediator.Send(new GetAwardByIdQuery(id)));

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] Guid? articleId, [FromQuery] bool? isActived) => Ok(await _mediator.Send(new GetListAwardQuery(articleId, isActived)));
}
