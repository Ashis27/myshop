using FluentValidation;
using Microsoft.Extensions.Logging;
using MyShop.Basket.Application.CommandAndHandlers;
using MyShop.Basket.Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.Validations
{
    public class BasketCommandValidator : AbstractValidator<BasketCommand>
    {
        public BasketCommandValidator(ILogger<BasketCommandValidator> logger)
        {
            RuleFor(command => command.BuyerId).NotEmpty().WithMessage("User is not associated with basket items");
            RuleFor(command => command.BasketItems).NotEmpty().NotNull().Must(ContainOrderItems).WithMessage("No items found");
            RuleFor(command => command.BasketItems).NotEmpty().NotNull().Must(IsValidQuantity).WithMessage("Quantity must be gretter than 0");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

        private bool IsValidQuantity(List<BasketItem> arg)
        {
            var count = arg.Where(p => p.Quantity < 1).Count();

            return count > 0 ? false : true;
        }

        private bool ContainOrderItems(List<BasketItem> arg)
        {
            return arg.Count > 0;
        }
    }
}
