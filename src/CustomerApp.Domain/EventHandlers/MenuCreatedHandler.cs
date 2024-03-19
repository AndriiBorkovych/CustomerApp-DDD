using System.Diagnostics;
using CustomerApp.Domain.Events;
using MediatR;

namespace CustomerApp.Domain.EventHandlers;

public class MenuCreatedHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        Debug.WriteLine(notification.Menu.Name);
        return Task.CompletedTask;
    }
}