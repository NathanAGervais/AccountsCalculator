using AccountCalculator.Commands;
using FluentValidation;

namespace AccountCalculator.Validation
{
    public class CreateAccountStatementValidator : AbstractValidator<CreateAccountStatementRequest>
    {
        public CreateAccountStatementValidator()
        {
            RuleFor(x => x.AccountId).NotEmpty();
            RuleFor(x => x.Transactions).NotEmpty();
            RuleForEach(x => x.Transactions)
                .OverrideIndexer((x, collection, element, index) => $"at index: {index} ")
                .SetValidator(new TransactionDtoValidator());
        }
    }
}
