﻿using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<User>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).Length(2);
        }
    }
}