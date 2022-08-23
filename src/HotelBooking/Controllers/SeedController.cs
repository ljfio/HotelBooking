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
    public async Task<IActionResult> SeedAsync() => await MediateAsync(new SeedDatabaseCommand());

    [HttpPost]
    [Route("reset")]
    public async Task<IActionResult> ResetAsync() => await MediateAsync(new ResetDatabaseCommand());
}