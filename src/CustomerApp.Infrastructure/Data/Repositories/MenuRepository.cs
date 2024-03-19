using CustomerApp.Application.Contracts;
using CustomerApp.Domain.AggregateRoots;
using CustomerApp.Domain.Entities;

namespace CustomerApp.Infrastructure.Data.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly DinnerDbContext _dbContext;

    public MenuRepository(DinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddAsync(Menu menu)
    {
        _dbContext.Add(menu);
        await _dbContext.SaveChangesAsync();
    }
}