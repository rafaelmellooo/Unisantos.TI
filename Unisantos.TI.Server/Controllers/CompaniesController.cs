using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.UseCases.Company;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
[Route("companies")]
public class CompaniesController : Controller
{
    private readonly GetCompaniesUseCase _getCompaniesUseCase;

    public CompaniesController(GetCompaniesUseCase getCompaniesUseCase)
    {
        _getCompaniesUseCase = getCompaniesUseCase;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SuccessResponse<CompanyResponseDTO[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompanies([FromQuery] GetCompaniesInputDTO request)
    {
        try
        {
            var response = await _getCompaniesUseCase.Execute(request);

            return Ok(new SuccessResponse<CompanyResponseDTO[]>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}