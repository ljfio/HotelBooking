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
    public async Task<IActionResult> CreateAsync([FromBody] CreateBookingModel model) => 
        await MediateAsync(new CreateBookingCommand(model.StartDate.Date, model.EndDate.Date, model.Rooms));

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetAsync(Guid id) => await MediateAsync(new GetBookingRequest(id));
}