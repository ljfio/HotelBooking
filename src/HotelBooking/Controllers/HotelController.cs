using System;
using System.Threading.Tasks;
using HotelBooking.Core.Models;
using HotelBooking.Core.Requests;
using HotelBooking.Models;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

[Route("[controller]")]
public class HotelController : ApiControllerBase
{
    public HotelController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetHotelsAsync(string? name = null)
    {
        var request = new GetHotelsRequest(name);

        var response = await Mediator.Send(request);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:guid}/rooms")]
    public async Task<IActionResult> GetAvailabilityAsync(Guid id, [FromQuery]RoomAvailabilityModel model)
    {
        var request = new RoomAvailabilityRequest(id, model.StartDate.Date, model.EndDate.Date, model.NumberOfPeople);

        var response = await Mediator.Send(request);

        if (response.IsFailed)
        {
            return BadRequest(response.Reasons);
        }
        
        return Ok(response.Value);
    }
}