using FluentValidation;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;

namespace OnionVb02.ValidatorStructure.Validators.AppUserValidators;

public class CreateAppUserCommandValidator : AbstractValidator<CreateAppUserCommand>
{
    public CreateAppUserCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz!")
            .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalı!")
            .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olabilir!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz!")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı!")
            .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir!");
    }
}

public class UpdateAppUserCommandValidator : AbstractValidator<UpdateAppUserCommand>
{
    public UpdateAppUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçerli bir kullanıcı ID'si giriniz!");

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Kullanıcı adı boş olamaz!")
            .MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalı!")
            .MaximumLength(50).WithMessage("Kullanıcı adı en fazla 50 karakter olabilir!");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre boş olamaz!")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı!")
            .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir!");
    }
}

