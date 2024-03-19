﻿using CustomerApp.Application.Contracts.Requests;
using CustomerApp.Application.Contracts.Responses;
using CustomerApp.Application.Features.Menu.Commands.CreateMenu;
using CustomerApp.Domain.AggregateRoots;
using Mapster;
using MenuItem = CustomerApp.Domain.Entities.MenuItem;
using MenuSection = CustomerApp.Domain.Entities.MenuSection;

namespace CustomerApp.API.Common.MappingConfigurations;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(m => m.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

    }
}