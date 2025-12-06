using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;

namespace OnionVb02.ValidatorStructure.Validators.AppUserProfileValidators;

public class CreateAppUserProfileCommandValidator : AbstractValidator<CreateAppUserProfileCommand>
{
    public CreateAppUserProfileCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz!")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir!");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz!")
            .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir!");

        RuleFor(x => x.AppUserId)
            .GreaterThan(0).WithMessage("Geçerli bir kullanıcı seçiniz!");
    }
}

public class UpdateAppUserProfileCommandValidator : AbstractValidator<UpdateAppUserProfileCommand>
{
    public UpdateAppUserProfileCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçerli bir profil ID'si giriniz!");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz!")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir!");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz!")
            .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir!");
    }
}
