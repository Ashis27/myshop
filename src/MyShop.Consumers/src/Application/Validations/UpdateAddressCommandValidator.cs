using Microsoft.Extensions.Logging;
using MyShop.Consumer.Application.Commands.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.Validations
{
    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator(ILogger<UpdateAddressCommand> logger)
        {
            RuleFor(command => command.Id).NotEmpty().GreaterThan(0).WithMessage($"Address with given id not found");
            RuleFor(command => command.Address.UserId).NotEmpty().WithMessage($"User associated with current address not found");
            RuleFor(command => command.Address.City).NotEmpty();
            RuleFor(command => command.Address.Country).NotEmpty();
            RuleFor(command => command.Address.State).NotEmpty();
            RuleFor(command => command.Address.Street).NotEmpty();
            RuleFor(command => command.Address.ZipCode).NotEmpty().NotNull().Length(6).WithMessage("Please select a valid 6 digits code");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
