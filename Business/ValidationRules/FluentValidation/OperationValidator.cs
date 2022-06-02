using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationValidator : AbstractValidator<Operation>
    {
        public OperationValidator()
        {
            RuleFor(n => n.Price).NotEmpty().WithMessage("Prica    bilgisi boş olamaz.");
            RuleFor(n => n.CompanyId).NotEmpty().WithMessage("Şirket Id   bilgisi boş olamaz.");
            RuleFor(n => n.CustomerName).NotEmpty().WithMessage("CustomerName    bilgisi boş olamaz.");
            RuleFor(n => n.CurrencyId).NotEmpty().WithMessage("CurrencyId    bilgisi boş olamaz.");
            RuleFor(n => n.OperationTime).NotEmpty().WithMessage("OperationTime    bilgisi boş olamaz.");
            RuleFor(n => n.CustomerName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
            
        }
    }
}
