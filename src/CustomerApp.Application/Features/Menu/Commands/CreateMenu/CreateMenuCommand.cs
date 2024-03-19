using ErrorOr;
using MediatR;

namespace CustomerApp.Application.Features.Menu.Commands.CreateMenu;

public record CreateMenuCommand(
    string Name,
    string Description,
    string HostId,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Domain.AggregateRoots.Menu>>;
    
public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);