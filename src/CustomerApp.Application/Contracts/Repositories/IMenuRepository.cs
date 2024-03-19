using CustomerApp.Domain.AggregateRoots;

namespace CustomerApp.Application.Contracts;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);
}