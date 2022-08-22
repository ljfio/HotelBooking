using System;
using System.Threading.Tasks;
using HotelBooking.Core.Commands;
using HotelBooking.Core.Models;
using HotelBooking.Core.Requests;
using HotelBooking.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

[Route("[controller]")]
public class BookingController : ApiControllerBase
{
    public BookingController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateBookingModel model)
    {
        var request = new CreateBookingCommand(model.StartDate.Date, model.EndDate.Date, model.Rooms);

        var response = await Mediator.Send(request);

        if (response.IsFailed)
        {
            return BadRequest(response.Reasons);
        }

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var request = new GetBookingRequest(id);

        var response = await Mediator.Send(request);

        return Ok(response);
    }
}