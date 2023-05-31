using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.UseCases.Address;
using Unisantos.TI.Domain.DTO.Address;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
public class AdressesController : Controller
{
    private readonly GetStatesUseCase _getStatesUseCase;
    private readonly GetCitiesUseCase _getCitiesUseCase;

    public AdressesController(GetStatesUseCase getStatesUseCase, GetCitiesUseCase getCitiesUseCase)
    {
        _getStatesUseCase = getStatesUseCase;
        _getCitiesUseCase = getCitiesUseCase;
    }

    [HttpGet("states")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SuccessResponse<StateResponseDTO[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetStates([FromQuery] GetStatesInputDTO request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getStatesUseCase.Execute(request, cancellationToken);

            return Ok(new SuccessResponse<StateResponseDTO[]>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }

    [HttpGet("states/{state:alpha}/cities")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SuccessResponse<CityResponseDTO[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCities([FromRoute] string state, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getCitiesUseCase.Execute(new GetCitiesInputDTO
            {
                State = state
            }, cancellationToken);

            return Ok(new SuccessResponse<CityResponseDTO[]>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}