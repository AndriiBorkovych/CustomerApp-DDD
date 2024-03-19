using CustomerApp.Application.Contracts.Requests;
using CustomerApp.Application.Contracts.Responses;
using CustomerApp.Application.Features.Menu.Commands.CreateMenu;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MenuController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("CreateMenu")]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var result = await _mediator.Send(command);
        return result.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            _ => Problem(statusCode: StatusCodes.Status500InternalServerError, title: "Internal error"));
    }
}