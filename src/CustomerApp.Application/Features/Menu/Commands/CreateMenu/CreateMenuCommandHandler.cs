using CustomerApp.Application.Contracts;
using CustomerApp.Domain.Entities;
using CustomerApp.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace CustomerApp.Application.Features.Menu.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Domain.AggregateRoots.Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Domain.AggregateRoots.Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        var menu = Domain.AggregateRoots.Menu.Create(
            request.Name,
            request.Description,
            HostId.Create(request.HostId),
            request.Sections.ConvertAll(
                section => 
                    MenuSection.Create(
                        section.Name,
                        section.Description,
                        section.Items.ConvertAll(
                            item => MenuItem.Create(
                                item.Name, item.Description))
                            ))
                );

        await _menuRepository.AddAsync(menu);

        return menu;
    }
}