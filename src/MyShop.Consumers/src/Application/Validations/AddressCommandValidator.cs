using FluentValidation;
using Microsoft.Extensions.Logging;
using MyShop.Consumer.Application.Commands.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Validations
{
    public class AddAddressCommandValidator:AbstractValidator<AddressCommand>
    {
        public AddAddressCommandValidator(ILogger<AddressCommand> logger)
        {
            RuleFor(command => command.City).NotEmpty();
            RuleFor(command => command.Country).NotEmpty();
            RuleFor(command => command.State).NotEmpty();
            RuleFor(command => command.Street).NotEmpty();
            RuleFor(command => command.ZipCode).NotEmpty().NotNull().Length(6).WithMessage("Please select a valid 6 digits code");
  
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
