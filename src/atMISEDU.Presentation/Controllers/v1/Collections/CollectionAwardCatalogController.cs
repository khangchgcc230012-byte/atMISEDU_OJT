using Asp.Versioning;
using atMISEDU.Application.Requests.Collections.CollectionAwardCatalog;
using atMISEDU.Presentation.Abstractions;
using atMISEDU.Presentation.Constants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace atMISEDU.Presentation.Controllers.v1.Collections
{
    [ApiVersion(1)]
    [Route(RouteConstant.API_PREFIX + RouteConstant.COLLECTION_AWARD_CATALOG_ROUTE)]
    public class CollectionAwardCatalogController : ApiController
    {
        private readonly IMediator mediator;

        public CollectionAwardCatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [MapToApiVersion(1)]
        [HttpPost]
        public async Task<IActionResult> CreateV1([FromBody] CreateCollectionAwardCatalogRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [MapToApiVersion(1)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateV1(int id, [FromBody] UpdateCollectionAwardCatalogRequest request)
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Ok(result);
        }

        [MapToApiVersion(1)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteV1(int id)
        {
            var command = new DeleteCollectionAwardCatalogRequest { Id = id };
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailV1(int id)
        {
            var query = new GetDetailCollectionAwardCatalogRequest { Id = id };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public async Task<IActionResult> GetAllV1([FromQuery] GetAllCollectionAwardCatalogRequest query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}