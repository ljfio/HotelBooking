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
    public async Task<IActionResult> GetHotelsAsync(string? name = null) => 
        await MediateAsync(new GetHotelsRequest(name));

    [HttpGet]
    [Route("{id:guid}/rooms")]
    public async Task<IActionResult> GetAvailabilityAsync(Guid id, [FromQuery]RoomAvailabilityModel model) =>
        await MediateAsync(new RoomAvailabilityRequest(id, model.StartDate.Date, model.EndDate.Date, model.NumberOfPeople));
}