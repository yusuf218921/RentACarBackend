using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(u => u.Email).Must(IsValidEmail);
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(U => U.LastName).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).Must(MustContainANumber);
        }

        private bool MustContainANumber(string arg)
        {
            
            foreach (var item in arg)
            {
                if (int.TryParse(item.ToString(), out _))
                    return true;
            }
            return false;
        }

        private bool IsValidEmail(string arg)
        {
            if(arg.Contains("@")) { return true; }
            return false;
        }
    }
}
