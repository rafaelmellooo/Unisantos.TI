using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.UseCases.Company;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
public class RatesController : Controller
{
    private readonly RateCompanyUseCase _rateCompanyUseCase;

    public RatesController(RateCompanyUseCase rateCompanyUseCase)
    {
        _rateCompanyUseCase = rateCompanyUseCase;
    }

    [HttpPost("companies/{companyId:guid}/rates")]
    [ProducesResponseType(typeof(SuccessResponse<RateResponseDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RateCompany([FromRoute] Guid companyId, [FromBody] RateCompanyBodyInputDTO request)
    {
        try
        {
            var response = await _rateCompanyUseCase.Execute(new RateCompanyInputDTO
            {
                CompanyId = companyId,
                Rate = request.Rate,
                Comment = request.Comment
            });

            return Ok(new SuccessResponse<RateResponseDTO>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}