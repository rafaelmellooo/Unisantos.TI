using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.Helpers;
using Unisantos.TI.Core.UseCases.Session;
using Unisantos.TI.Domain.DTO.Session;
using Unisantos.TI.Domain.DTO.Token;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
[Route("sessions")]
public class SessionsController : Controller
{
    private readonly CreateSessionUseCase _createSessionUseCase;

    public SessionsController(CreateSessionUseCase createSessionUseCase)
    {
        _createSessionUseCase = createSessionUseCase;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SuccessResponse<TokenResponseDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSession([FromBody] CreateSessionInputDTO request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _createSessionUseCase.Execute(request, cancellationToken);

            return Ok(new SuccessResponse<TokenResponseDTO>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}