using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(expression: p => p.ProductName).NotEmpty();
            RuleFor(expression: p => p.ProductName).Length(2, 30);
            RuleFor(expression:p=>p.UnitPrice).NotEmpty();
            RuleFor(expression:p=>p.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(expression: p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(expression: p => p.ProductName).Must(StartWithA);


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
