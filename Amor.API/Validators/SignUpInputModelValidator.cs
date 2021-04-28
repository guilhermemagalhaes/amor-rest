using Amor.Application.InputModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amor.API.Validators
{
    public class SignUpInputModelValidator : AbstractValidator<SignUpInputModel>
    {
        public SignUpInputModelValidator()
        {
            RuleFor(cp => cp.Email)
                .NotNull().WithMessage($"{nameof(SignUpInputModel.Email)} é obrigatiorio")
                .NotEmpty().WithMessage($"{nameof(SignUpInputModel.Email)} é obrigatiorio")
                .EmailAddress().WithMessage("E-mail invalido");

            RuleFor(cp => cp.Password)
                .NotNull().WithMessage($"{nameof(SignUpInputModel.Password)} é obrigatiorio")
                .NotEmpty().WithMessage($"{nameof(SignUpInputModel.Password)} é obrigatiorio")
                .MinimumLength(6)
                .WithMessage("A senha deve conter no mínimo 6 caracteres");

            RuleFor(cp => cp.Document)
                .NotNull()
                .NotEmpty()
                .WithMessage($"{nameof(SignUpInputModel.Document)} é obrigatiorio");
        }
    }
}
