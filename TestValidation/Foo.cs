using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidation
{
    public class Foo
    {
        public void Validate()
        {
            User user = new User()
            {
                FirstName = "Василий",
                LastName = "Пупкин"
            };
            UserValidationService userValidationService = new UserValidationService();
            ValidationResult result = userValidationService.Validate(user);
            if (result.IsValid)
            {
                return;
            }
            foreach (ValidationFailure failure in result.Errors)
            {
                Console.WriteLine($"{failure.ErrorCode} = { failure.PropertyName} { failure.ErrorMessage}");
            }
        }
    }
}
