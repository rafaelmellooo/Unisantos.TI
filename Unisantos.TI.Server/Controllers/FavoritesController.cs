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
    private readonly GetFavoriteCompaniesUseCase _getFavoriteCompaniesUseCase;

    public FavoritesController(FavoriteCompanyUseCase favoriteCompanyUseCase,
        GetFavoriteCompaniesUseCase getFavoriteCompaniesUseCase)
    {
        _favoriteCompanyUseCase = favoriteCompanyUseCase;
        _getFavoriteCompaniesUseCase = getFavoriteCompaniesUseCase;
    }

    [Authorize]
    [HttpPost("companies/{companyId:guid}/favorites")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FavoriteCompany([FromRoute] Guid companyId, CancellationToken cancellationToken)
    {
        try
        {
            await _favoriteCompanyUseCase.Execute(new FavoriteCompanyInputDTO
            {
                CompanyId = companyId
            }, cancellationToken);

            return NoContent();
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }

    [Authorize]
    [HttpGet("companies/favorites")]
    [ProducesResponseType(typeof(SuccessResponse<CompanyResponseDTO[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFavoriteCompanies([FromQuery] GetFavoriteCompaniesInputDTO request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getFavoriteCompaniesUseCase.Execute(request, cancellationToken);

            return Ok(new SuccessResponse<CompanyResponseDTO[]>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}