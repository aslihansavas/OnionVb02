using Microsoft.Extensions.DependencyInjection;
using OnionVb02.Application.CustomMappers.Interfaces;
using OnionVb02.Application.CustomMappers.CommandMappers;
using OnionVb02.Application.CustomMappers.ResultMappers;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserResults;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.AppUserProfileResults;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CustomMappers.DependencyResolvers;

public static class MapperResolver
{
    public static IServiceCollection AddCustomMappers(this IServiceCollection services)
    {
        // Product Mappers
        services.AddScoped<ICustomMapper<CreateProductCommand, Product>, CreateProductCommandMapper>();
        services.AddScoped<ICustomMapper<UpdateProductCommand, Product>, UpdateProductCommandMapper>();
        services.AddScoped<ICustomMapper<RemoveProductCommand, Product>, RemoveProductCommandMapper>();
        services.AddScoped<ICustomMapper<Product, GetProductsQueryResult>, ProductToResultMapper>();
        services.AddScoped<ICustomMapper<Product, GetProductByIdQueryResult>, ProductToByIdResultMapper>();

        // Category Mappers
        services.AddScoped<ICustomMapper<CreateCategoryCommand, Category>, CreateCategoryCommandMapper>();
        services.AddScoped<ICustomMapper<UpdateCategoryCommand, Category>, UpdateCategoryCommandMapper>();
        services.AddScoped<ICustomMapper<RemoveCategoryCommand, Category>, RemoveCategoryCommandMapper>();
        services.AddScoped<ICustomMapper<Category, GetCategoryQueryResult>, CategoryToResultMapper>();
        services.AddScoped<ICustomMapper<Category, GetCategoryByIdResult>, CategoryToByIdResultMapper>();

        // Order Mappers
        services.AddScoped<ICustomMapper<CreateOrderCommand, Order>, CreateOrderCommandMapper>();
        services.AddScoped<ICustomMapper<UpdateOrderCommand, Order>, UpdateOrderCommandMapper>();
        services.AddScoped<ICustomMapper<RemoveOrderCommand, Order>, RemoveOrderCommandMapper>();
        services.AddScoped<ICustomMapper<Order, GetOrdersQueryResult>, OrderToResultMapper>();
        services.AddScoped<ICustomMapper<Order, GetOrderByIdQueryResult>, OrderToByIdResultMapper>();

        // OrderDetail Mappers
        services.AddScoped<ICustomMapper<CreateOrderDetailCommand, OrderDetail>, CreateOrderDetailCommandMapper>();
        services.AddScoped<ICustomMapper<UpdateOrderDetailCommand, OrderDetail>, UpdateOrderDetailCommandMapper>();
        services.AddScoped<ICustomMapper<RemoveOrderDetailCommand, OrderDetail>, RemoveOrderDetailCommandMapper>();
        services.AddScoped<ICustomMapper<OrderDetail, GetOrderDetailsQueryResult>, OrderDetailToResultMapper>();
        services.AddScoped<ICustomMapper<OrderDetail, GetOrderDetailByIdQueryResult>, OrderDetailToByIdResultMapper>();

        // AppUser Mappers
        services.AddScoped<ICustomMapper<CreateAppUserCommand, AppUser>, CreateAppUserCommandMapper>();
        services.AddScoped<ICustomMapper<UpdateAppUserCommand, AppUser>, UpdateAppUserCommandMapper>();
        services.AddScoped<ICustomMapper<RemoveAppUserCommand, AppUser>, RemoveAppUserCommandMapper>();
        services.AddScoped<ICustomMapper<AppUser, GetAppUserQueryResult>, AppUserToResultMapper>();
        services.AddScoped<ICustomMapper<AppUser, GetAppUserByIdQueryResult>, AppUserToByIdResultMapper>();

        // AppUserProfile Mappers
        services.AddScoped<ICustomMapper<CreateAppUserProfileCommand, AppUserProfile>, CreateAppUserProfileCommandMapper>();
        services.AddScoped<ICustomMapper<UpdateAppUserProfileCommand, AppUserProfile>, UpdateAppUserProfileCommandMapper>();
        services.AddScoped<ICustomMapper<RemoveAppUserProfileCommand, AppUserProfile>, RemoveAppUserProfileCommandMapper>();
        services.AddScoped<ICustomMapper<AppUserProfile, GetAppUserProfileQueryResult>, AppUserProfileToResultMapper>();
        services.AddScoped<ICustomMapper<AppUserProfile, GetAppUserProfileByIdQueryResult>, AppUserProfileToByIdResultMapper>();

        return services;
    }
}

