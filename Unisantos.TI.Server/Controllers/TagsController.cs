using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisantos.TI.Core.UseCases.Company;
using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Server.Responses;

namespace Unisantos.TI.Server.Controllers;

[ApiController]
[Route("tags")]
public class TagsController : Controller
{
    private readonly GetTagsUseCase _getTagsUseCase;

    public TagsController(GetTagsUseCase getTagsUseCase)
    {
        _getTagsUseCase = getTagsUseCase;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SuccessResponse<TagSectionResponseDTO[]>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTags(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _getTagsUseCase.Execute(new GetTagsInputDTO(), cancellationToken);

            return Ok(new SuccessResponse<TagSectionResponseDTO[]>(response));
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}