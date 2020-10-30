using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FristName).NotEmpty().WithMessage("FristName is required")
                .MaximumLength(100).WithMessage("FristName is over 100 character");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
                .MaximumLength(100).WithMessage("LastName is over 100 character");
            RuleFor(x => x.Dob).NotEmpty().WithMessage("DateOfBirthday is required")
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 year");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@" ^ ([\w\.\-] +)@([\w\-] +)((\.(\w){ 2,3})+)$").WithMessage("Email format not match");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required")
                .Matches(@"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$").WithMessage("PhoneNumber format not match");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is least than 6 character");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });




        }
    }
}
