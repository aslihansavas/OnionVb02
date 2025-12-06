using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionVb02.ValidatorStructure.Behaviors;
using OnionVb02.ValidatorStructure.Validators.ProductValidators;

namespace OnionVb02.ValidatorStructure.DependencyResolvers;

public static class ValidatorResolver
{
    public static IServiceCollection AddValidatorServices(this IServiceCollection services)
    {
        // Bu assembly'deki tüm validator'ları otomatik kaydet
        services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
        
        // MediatR Pipeline Behavior - otomatik validation
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}

