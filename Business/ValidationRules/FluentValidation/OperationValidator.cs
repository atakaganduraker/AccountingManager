using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation
{
    public class OperationValidator:AbstractValidator<Operation>
    {
        public OperationValidator()
        {

            RuleFor(n=>n.CompanyId).NotEmpty().WithMessage("Şirket Id boş  bilgisi boş olamaz.");
            
        }

      
    }
}
