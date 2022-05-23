using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidation
{
    public sealed class UserValidationService : AbstractValidator<User>
    {
        public UserValidationService()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Имя не должно быть пустым")
            .WithErrorCode("BRL-100.1");
            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не должна быть пустым")
            .WithErrorCode("BRL-100.2");
            RuleFor(x => x.MiddleName)
            .NotEmpty()
            .WithMessage("Отчество не должно быть пустым")
            .WithErrorCode("BRL-100.3");
        }
    }
}
