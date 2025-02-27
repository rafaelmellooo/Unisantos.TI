﻿using Microsoft.AspNetCore.Mvc;
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserInputDTO request,
        CancellationToken cancellationToken)
    {
        try
        {
            await _createUserUseCase.Execute(request, cancellationToken);

            return NoContent();
        }
        catch (Exception exception)
        {
            return BadRequest(new ErrorResponse(exception.Message));
        }
    }
}