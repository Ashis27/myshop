using FluentValidation;
using Microsoft.Extensions.Logging;
using MyShop.Identity.CommandHandlers.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly Regex EmailRegex = new Regex(
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        public CreateUserCommandValidator(ILogger<CreateUserCommandValidator> logger)
        {
            RuleFor(s => s.FirstName).NotEmpty().Length(2,50).WithMessage("Length must be gretter than or equal to 2 letters");
            RuleFor(s => s.Email).NotEmpty().Must(ValidateEmail).WithMessage("Invalid email address");
            RuleFor(s => s.Role).NotEmpty().NotNull();
            RuleFor(s => s.Password).NotEmpty();//.Must(ValidatePassword).WithMessage("Invalid password");
        }

        private bool ValidateEmail(string email)
        {
            return EmailRegex.IsMatch(email);
        }

        //private bool ValidatePassword(string email)
        //{
        //    return EmailRegex.IsMatch(email);
        //}
    }
}
