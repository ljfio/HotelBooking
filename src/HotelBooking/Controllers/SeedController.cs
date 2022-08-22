using System.Threading.Tasks;
using HotelBooking.Core.Commands;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers;

[Route("[controller]")]
public class SeedController : ApiControllerBase
{
    public SeedController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> SeedAsync()
    {
        var request = new SeedDatabaseCommand();

        await Mediator.Send(request);

        return Ok();
    }

    [HttpPost]
    [Route("reset")]
    public async Task<IActionResult> ResetAsync()
    {
        var request = new ResetDatabaseCommand();

        await Mediator.Send(request);

        return Ok();

    }
}