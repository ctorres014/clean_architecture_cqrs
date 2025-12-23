using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetails;
using GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GloboTicket.TicketManagment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDto>> GetAllEvents()
        {
            var listEvents = await _mediator.Send(new GetEventListQuery());
            return Ok(listEvents);
        }

        [HttpGet("detail", Name = "GetEventsDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDto>> GetEventsDetails(Guid guid)
        {
            GetEventDetailsQuery getEventDetailsQuery = new GetEventDetailsQuery
            {
                Id = guid
            };
            var listEvents = await _mediator.Send(getEventDetailsQuery);
            return Ok(listEvents);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Add([FromBody] CreateEventCommand createEventCommand)
        {
            var @eventId = await _mediator.Send(createEventCommand);
            return Ok(@eventId);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> update([FromBody] UpdateEventCommand updateEventCommand)
        {
            await _mediator.Send(updateEventCommand);
            return Ok();
        }

        [HttpPost("{id}", Name = "delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> delete(Guid id)
        {
            DeleteEventCommand deleteEventCommand = new DeleteEventCommand
            {
                EventId = id
            };
            await _mediator.Send(deleteEventCommand);
            return Ok();
        }
    }
}
