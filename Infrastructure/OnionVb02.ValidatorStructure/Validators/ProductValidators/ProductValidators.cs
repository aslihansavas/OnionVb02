using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;

namespace OnionVb02.ValidatorStructure.Validators.ProductValidators;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Ürün adı boş olamaz!")
            .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalı!")
            .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir!");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı!");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Kategori seçilmelidir!");
    }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçerli bir ürün ID'si giriniz!");

        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Ürün adı boş olamaz!")
            .MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalı!")
            .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter olabilir!");

        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalı!");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Kategori seçilmelidir!");
    }
}
