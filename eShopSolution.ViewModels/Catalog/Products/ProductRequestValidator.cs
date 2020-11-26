using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductRequestValidator : AbstractValidator<ProductCreateRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name is not null");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price Name is not null");
            RuleFor(x => x.OriginalPrice).NotEmpty().WithMessage("OriginalPrice Name is not null");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock Name is not null");
        }
    }
}
