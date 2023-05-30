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
    private readonly GetCompanyDetailsUseCase _getCompanyDetailsUseCase;
    private readonly CreateCompanyUseCase _createCompanyUseCase;
    private readonly DeleteCompanyUseCase _deleteCompanyUseCase;

    public CompaniesController(GetCompaniesUseCase getCompaniesUseCase,
        GetCompanyDetailsUseCase getCompanyDetailsUseCase, CreateCompanyUseCase createCompanyUseCase,
        DeleteCompanyUseCase deleteCompanyUseCase)
    {
        _getCompaniesUseCase = getCompaniesUseCase;
        _getCompanyDetailsUseCase = getCompanyDetailsUseCase;
        _createCompanyUseCase = createCompanyUseCase;
        _deleteCompanyUseCase = deleteCompanyUseCase;
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

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SuccessResponse<CompanyDetailsResponseDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompanyDetails([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getCompanyDetailsUseCase.Execute(new GetCompanyDetailsInputDTO
            {
                Id = id
            }, cancellationToken);

            return Ok(new SuccessResponse<CompanyDetailsResponseDTO>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }

    [HttpPost]
    [Authorize(Policy = "Admin")]
    [ProducesResponseType(typeof(SuccessResponse<CreateCompanyResponseDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyInputDTO request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _createCompanyUseCase.Execute(request, cancellationToken);

            return Ok(new SuccessResponse<CreateCompanyResponseDTO>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCompany([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await _deleteCompanyUseCase.Execute(new DeleteCompanyInputDTO
            {
                Id = id
            }, cancellationToken);

            return NoContent();
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}