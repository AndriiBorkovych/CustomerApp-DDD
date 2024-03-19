using CustomerApp.Domain.AggregateRoots;
using CustomerApp.Domain.Common;
using CustomerApp.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerApp.Infrastructure.Data;

public class DinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _domainEventsInterceptor;
    public DinnerDbContext(DbContextOptions<DinnerDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<Menu> Menus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);
        
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(DinnerDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}