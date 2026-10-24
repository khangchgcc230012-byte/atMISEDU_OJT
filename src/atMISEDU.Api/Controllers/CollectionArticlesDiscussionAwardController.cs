using atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.CreateDiscussionAward;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.DeleteDiscussionAward;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.GetDiscussionAwardById;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.GetListDiscussionAward;
using atMISEDU.Application.UserCases.Collection.CollectionArticlesDiscussionAward.UpdateDiscussionAward;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDUatMISEDUAPI.Controllers;

[ApiController]
[Route("v1/collections/CollectionArticlesDiscussionAward")]
public class CollectionArticlesDiscussionAwardController : ControllerBase
{
    private readonly ISender _mediator;
    public CollectionArticlesDiscussionAwardController(ISender mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDiscussionAwardCommand command) => Ok(await _mediator.Send(command));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDiscussionAwardCommand command)
    {
        var cmd = new UpdateDiscussionAwardCommand(id, command.AwardId, command.IsActived);
        await _mediator.Send(cmd);
        return Ok(null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteDiscussionAwardCommand(id));
        return Ok(null);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await _mediator.Send(new GetDiscussionAwardByIdQuery(id)));

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] Guid? discussionId, [FromQuery] bool? isActived) => Ok(await _mediator.Send(new GetListDiscussionAwardQuery(discussionId, isActived)));
}
