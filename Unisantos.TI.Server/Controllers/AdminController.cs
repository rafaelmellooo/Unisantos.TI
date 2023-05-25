using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.UseCases.Admin;
using Unisantos.TI.Domain.DTO.Admin;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
[Route("admin")]
[Authorize(Policy = "Admin")]
public class AdminController : Controller
{
    private readonly GetAdminCompaniesUseCase _getAdminCompaniesUseCase;

    public AdminController(GetAdminCompaniesUseCase getAdminCompaniesUseCase)
    {
        _getAdminCompaniesUseCase = getAdminCompaniesUseCase;
    }

    [HttpGet("companies")]
    [ProducesResponseType(typeof(SuccessResponse<CompanyResponseDTO[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAdminCompanies([FromQuery] GetAdminCompaniesInputDTO request)
    {
        try
        {
            var response = await _getAdminCompaniesUseCase.Execute(request);

            return Ok(new SuccessResponse<CompanyResponseDTO[]>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}