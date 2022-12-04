using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.UseCases.Company;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
public class FavoritesController : Controller
{
    private readonly FavoriteCompanyUseCase _favoriteCompanyUseCase;

    public FavoritesController(FavoriteCompanyUseCase favoriteCompanyUseCase)
    {
        _favoriteCompanyUseCase = favoriteCompanyUseCase;
    }

    [Authorize]
    [HttpPost("companies/{companyId:guid}/favorites")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FavoriteCompany([FromRoute] Guid companyId, CancellationToken cancellationToken)
    {
        try
        {
            await _favoriteCompanyUseCase.Execute(new FavoriteCompanyInputDTO
            {
                CompanyId = companyId
            }, cancellationToken);

            return Ok();
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}