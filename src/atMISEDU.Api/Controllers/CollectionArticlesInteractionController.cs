using System;
using System.Threading.Tasks;
using atMISEDU.Application.UserCases.ArticleInteractions.Commands;
using atMISEDU.Application.UserCases.ArticleInteractions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDU.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionArticlesInteractionController : ControllerBase
    {
        private readonly ISender _mediator;

        public CollectionArticlesInteractionController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{articleId:guid}/{userId:guid}")]
        public async Task<IActionResult> GetInteraction(Guid articleId, Guid userId)
        {
            var query = new GetArticleInteractionQuery(articleId, userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateInteraction([FromBody] CreateArticleInteractionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { Id = result, Message = "Interaction updated successfully." });
        }
    }
}