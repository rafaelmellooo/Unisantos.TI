using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.Helpers;
using Unisantos.TI.Core.UseCases.User;
using Unisantos.TI.Domain.DTO.User;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
[Route("users")]
public class UsersController : Controller
{
    private readonly CreateUserUseCase _createUserUseCase;

    public UsersController(CreateUserUseCase createUserUseCase)
    {
        _createUserUseCase = createUserUseCase;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserInputDTO request,
        CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new ErrorResponse(ModelState.GetErrorMessages()));
        }

        try
        {
            await _createUserUseCase.Execute(request, cancellationToken);

            return Ok();
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}