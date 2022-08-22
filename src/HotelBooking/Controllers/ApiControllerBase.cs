using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IMediator Mediator { get; }

    protected ApiControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }
}