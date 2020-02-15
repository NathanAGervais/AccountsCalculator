using AccountCalculator.Commands;
using AccountCalculator.Dtos;
using AccountCalculator.Validation;
using AutoFixture.NUnit3;
using FluentValidation.TestHelper;
using NUnit.Framework;
using System.Collections.Generic;

namespace AccountCalculator.Tests.Validators
{
    [TestFixture]
    public class CreateEndOfDayBalanceCalculationCommandValidatorTests
    {
        [Test, AutoData]
        public void CreateEndOfDayBalanceCalculationCommandValidator_HasNoValidationErrors_WhenAccountIdIsValid(CreateEndOfDayBalanceCalculationCommandValidator sut, CreateEndOfDaysBalanceCalculationCommand command)
        {
            sut.ShouldNotHaveValidationErrorFor(s => s.AccountId, command);
        }

        [Test, AutoData]
        public void CreateEndOfDayBalanceCalculationCommandValidator_HasValidationErrors_WhenAccountIdIsInvalid(CreateEndOfDayBalanceCalculationCommandValidator sut)
        {
            sut.ShouldHaveValidationErrorFor(s => s.AccountId, new CreateEndOfDaysBalanceCalculationCommand());
        }

        [Test, AutoData]
        public void CreateEndOfDayBalanceCalculationCommandValidator_HasNoValidationErrors_WhenransactionIsValid(CreateEndOfDayBalanceCalculationCommandValidator sut, CreateEndOfDaysBalanceCalculationCommand command)
        {
            sut.ShouldNotHaveValidationErrorFor(s => s.Transactions, command);
        }

        [Test, AutoData]
        public void CreateEndOfDayBalanceCalculationCommandValidator_HasValidationErrors_WhenTransactionsAreEmpty(CreateEndOfDayBalanceCalculationCommandValidator sut, CreateEndOfDaysBalanceCalculationCommand command)
        {
            command.Transactions = new List<TransactionDto>();
            sut.ShouldHaveValidationErrorFor(s => s.Transactions, command);
        }

        [Test, AutoData]
        public void CreateEndOfDayBalanceCalculationCommandValidator_HasChildValidator_ForTransactionsList(CreateEndOfDayBalanceCalculationCommandValidator sut)
        {
            sut.ShouldHaveChildValidator(s => s.Transactions, typeof(TransactionDtoValidator));
        }
    }
}
