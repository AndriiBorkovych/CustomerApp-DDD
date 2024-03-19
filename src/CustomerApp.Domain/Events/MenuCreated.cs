using CustomerApp.Domain.AggregateRoots;
using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.Events;

public record MenuCreated(Menu Menu) : IDomainEvent;