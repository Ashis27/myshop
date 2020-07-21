using FluentValidation;
using Microsoft.Extensions.Logging;
using MyShop.Catalog.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Validations
{
    public class UpdateCatalogItemCommandValidator : AbstractValidator<UpdateCatalogItemCommand>
    {
        public UpdateCatalogItemCommandValidator(ILogger<UpdateCatalogItemCommandValidator> logger)
        {
            RuleFor(command => command.Catalog.Name).NotEmpty();
            RuleFor(command => command.Catalog.Description).NotEmpty();
            RuleFor(command => command.Catalog.Price).NotNull().GreaterThan(0).WithMessage("Price value must be gretter than 0");
            RuleFor(command => command.Catalog.PictureFileName).NotEmpty().NotNull().WithMessage("Please select an catalog image");
            RuleFor(command => command.Catalog.CatalogBrandId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Please select a catalog brand");
            RuleFor(command => command.Catalog.CatalogTypeId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Please select a catalog type");
            RuleFor(command => command.Catalog.AvailableStock).NotNull().GreaterThan(0).WithMessage("Please specify available stock for selected catalog");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}
