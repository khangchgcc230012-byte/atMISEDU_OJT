using System;
using System.Threading.Tasks;
using atMISEDU.Application.UserCases.ArticleVotes.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDU.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionArticlesVoteController : ControllerBase
    {
        private readonly ISender _mediator;

        public CollectionArticlesVoteController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpsertVote([FromBody] CreateOrUpdateArticleVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { Id = result, Message = "Vote recorded successfully." });
        }

        [HttpDelete("{articleId:guid}/{userId:guid}")]
        public async Task<IActionResult> DeleteVote(Guid articleId, Guid userId)
        {
            var command = new DeleteArticleVoteCommand(articleId, userId);
            var isSuccess = await _mediator.Send(command);

            if (!isSuccess)
            {
                return NotFound(new { Message = "Vote record not found." });
            }

            return Ok(new { Message = "Vote removed successfully." });
        }
    }
}