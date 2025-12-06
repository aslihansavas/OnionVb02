using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.CategoryCommands;

namespace OnionVb02.ValidatorStructure.Validators.CategoryValidators;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Kategori adı boş olamaz!")
            .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalı!")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir!");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir!");
    }
}

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçerli bir kategori ID'si giriniz!");

        RuleFor(x => x.CategoryName)
            .NotEmpty().WithMessage("Kategori adı boş olamaz!")
            .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalı!")
            .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olabilir!");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir!");
    }
}

