using CustomerApp.Domain.Common;
using CustomerApp.Domain.Entities;
using CustomerApp.Domain.Events;
using CustomerApp.Domain.ValueObjects;

namespace CustomerApp.Domain.AggregateRoots;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    private Menu()
    {
    }
    
    private Menu(MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        List<MenuSection> sections) 
        : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
        _sections = sections;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    
    public static Menu Create(string name, 
        string description,
        HostId hostId,
        List<MenuSection> sections = null)
    {
        // Perform validation and creation logic
        var menu = new Menu(MenuId.CreateUnique(), 
            name, 
            description,
            AverageRating.CreateNew(),
            hostId,
            sections ?? []);
        
        menu.AddDomainEvent(new MenuCreated(menu));
        
        return menu;
    }
    
}