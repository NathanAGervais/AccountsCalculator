using AccountCalculator.Dtos;
using FluentValidation;

namespace AccountCalculator.Validation
{
    public class TransactionDtoValidator : AbstractValidator<TransactionDto>
    {
        public TransactionDtoValidator()
        {
            RuleFor(x => x.CreditDebitIndicator).NotNull();
            RuleFor(x => x.Status).NotNull();
        }
    }
}
