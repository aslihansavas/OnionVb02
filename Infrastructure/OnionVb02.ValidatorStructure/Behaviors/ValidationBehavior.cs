using FluentValidation;
using MediatR;

namespace OnionVb02.ValidatorStructure.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Validator yoksa direkt devam et
        if (!_validators.Any())
        {
            return await next();
        }

        // Tüm validator'ları çalıştır
        var context = new ValidationContext<TRequest>(request);
        
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );

        // Hataları topla
        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        // Hata varsa exception fırlat
        if (failures.Any())
        {
            throw new ValidationException(failures);
        }

        // Validation geçti, handler'a devam et
        return await next();
    }
}

