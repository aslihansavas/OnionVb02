using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;

namespace OnionVb02.ValidatorStructure.Validators.OrderValidators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("Teslimat adresi boş olamaz!")
            .MaximumLength(500).WithMessage("Teslimat adresi en fazla 500 karakter olabilir!");

        RuleFor(x => x.AppUserId)
            .GreaterThan(0).WithMessage("Geçerli bir kullanıcı seçiniz!");
    }
}

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçerli bir sipariş ID'si giriniz!");

        RuleFor(x => x.ShippingAddress)
            .NotEmpty().WithMessage("Teslimat adresi boş olamaz!")
            .MaximumLength(500).WithMessage("Teslimat adresi en fazla 500 karakter olabilir!");
    }
}
