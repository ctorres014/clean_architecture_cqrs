using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Features.Categories.Command.CreateCategory;
using GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryList;
using GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryListWithEvent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GloboTicket.TicketManagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name= "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategories()
        {
            var listCategories = await _mediator.Send( new GetCategoryListQuery());
            return Ok(listCategories);
        }

        [HttpGet("events", Name= "GetCategoryWithEvent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CategoryEventDto>>> GetCategoryWithEvent(bool includeHistory)
        {
            GetCategoryListWithEventQuery getCategoryListWithEventQuery = new GetCategoryListWithEventQuery() 
            { 
                IncludeHistory = includeHistory 
            };
            var categoriesWithEvent = await _mediator.Send(getCategoryListWithEventQuery);
            return Ok(categoriesWithEvent);
        }

        [HttpPost("add", Name = "AddCategory")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Add([FromBody] CreateCategoryCommandResponse createCategoryCommandResponse)
        {
            var response = await _mediator.Send(createCategoryCommandResponse);
            return Ok(response);
        }

    }
}
