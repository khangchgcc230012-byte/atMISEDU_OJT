using System;
using System.Threading.Tasks;
using atMISEDU.Application.UserCases.ArticleDiscussionInteractions.Commands; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDU.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionArticlesDiscussionInteractionController : ControllerBase
    {
        private readonly ISender _mediator;

        public CollectionArticlesDiscussionInteractionController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertInteraction([FromBody] CreateOrUpdateArticleDiscussionInteractionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { Id = result, Message = "Interaction recorded successfully." });
        }

        [HttpDelete("{discussionId:guid}/{userId:guid}")]
        public async Task<IActionResult> DeleteInteraction(Guid discussionId, Guid userId)
        {
            var command = new DeleteArticleDiscussionInteractionCommand(discussionId, userId);
            var isSuccess = await _mediator.Send(command);

            if (!isSuccess)
            {
                return NotFound(new { Message = "Interaction record not found." });
            }

            return Ok(new { Message = "Interaction removed successfully." });
        }
    }
}