using System.Threading.Tasks;
using FluentResults;
using HotelBooking.Core.Errors;
using Mediator;
using Microsoft.AspNetCore.Http;
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

    /// <summary>
    /// Use Mediator to handle the provided IRequest
    /// </summary>
    /// <param name="request"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    protected async ValueTask<IActionResult> MediateAsync<TResponse>(IRequest<Result<TResponse>> request)
        where TResponse : class
    {
        var result = await Mediator.Send(request);
        
        return HandleResult(result);
    }

    /// <summary>
    /// Use Mediator to handle the provided ICommand
    /// </summary>
    /// <param name="command"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    protected async ValueTask<IActionResult> MediateAsync<TResponse>(ICommand<Result<TResponse>> command)
        where TResponse : class
    {
        var result = await Mediator.Send(command);
        
        return HandleResult(result);
    }

    /// <summary>
    /// Use Mediator to handle the provided ICommand
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    protected async ValueTask<IActionResult> MediateAsync(ICommand request)
    {
        await Mediator.Send(request);

        return Ok();
    }

    /// <summary>
    /// Use Mediator to handle the provided IQuery
    /// </summary>
    /// <param name="command"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    protected async ValueTask<IActionResult> MediateAsync<TResponse>(IQuery<Result<TResponse>> command)
        where TResponse : class
    {
        var result = await Mediator.Send(command);

        return HandleResult(result);
    }

    /// <summary>
    /// Handle the Result
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private IActionResult HandleResult<T>(Result<T> result) where T : class
    {
        if (result.IsSuccess)
            return Ok(result.Value);
        
        if (result.HasError<IBadRequestError>())
            return BadRequest(result.Reasons);

        if (result.HasError<INotFoundError>())
            return NotFound(result.Reasons);

        return StatusCode(StatusCodes.Status500InternalServerError, result.Reasons);
    }
}