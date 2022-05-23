using SOLIDWebApplication.Models;
using SOLIDWebApplication.DAL.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace SOLIDWebApplication.Validation.Services
{
    internal sealed class PersonValidationService : FluentValidationService<Person>, IPersonValidationService
    {
        private readonly IPersonsService _personsService;
        public PersonValidationService(IPersonsService personService)
        {
            _personsService = personService;
            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("Имя не должно быть пустым")
            .WithErrorCode("BRL-100.1");
            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Фамилия не должна быть пустым")
            .WithErrorCode("BRL-100.2");
            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("E-mail не должен быть пустым")
            .WithErrorCode("BRL-100.3");
            RuleFor(x => x.FirstName).Custom((s, context) =>
            {
                if (_personsService.IsUserNameAlreadyExist(s))
                {
                    context.AddFailure(new ValidationFailure(nameof(Person.FirstName), "Пользователь уже существует")
                    {
                        ErrorCode = "BRL-100.4"
                    });
                }
            });
        }
    }
}
