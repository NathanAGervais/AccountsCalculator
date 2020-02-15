using AccountCalculator.Commands;
using FluentValidation;
using System;

namespace AccountCalculator.Validation
{
    public class CreateEndOfDayBalanceCalculationCommandValidator : AbstractValidator<CreateEndOfDaysBalanceCalculationCommand>
    {
        public CreateEndOfDayBalanceCalculationCommandValidator()
        {
            RuleFor(x => x.AccountId).NotEmpty();
            RuleFor(x => x.Transactions).NotEmpty();
            RuleForEach(x => x.Transactions)
                .OverrideIndexer((x, collection, element, index) => $"at index: {index} ")
                .SetValidator(new TransactionDtoValidator());
        }
    }
}
