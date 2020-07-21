using FluentValidation;
using Microsoft.Extensions.Logging;
using MyShop.Catalog.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Validations
{
    public class CreateCatalogItemCommandValidator : AbstractValidator<CatalogItemCommand>
    {
        public CreateCatalogItemCommandValidator(ILogger<CreateCatalogItemCommandValidator> logger)
        {
            RuleFor(command => command.Name).NotEmpty();
            RuleFor(command => command.Description).NotEmpty();
            RuleFor(command => command.Price).NotNull().GreaterThan(0).WithMessage("Price value must be gretter than 0");
            RuleFor(Command => Command.PictureFileName).NotEmpty().NotNull().WithMessage("Please select an catalog image");
            RuleFor(Command => Command.CatalogBrandId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Please select a catalog brand");
            RuleFor(Command => Command.CatalogTypeId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Please select a catalog type");
            RuleFor(command => command.AvailableStock).NotNull().GreaterThan(0).WithMessage("Please specify available stock for selected catalog");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
