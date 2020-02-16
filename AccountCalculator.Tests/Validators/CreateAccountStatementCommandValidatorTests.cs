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
    public class CreateAccountStatementCommandValidatorTests
    {
        [Test, AutoData]
        public void CreateAccountStatementCalculationCommandValidator_HasNoValidationErrors_WhenAccountIdIsValid(CreateAccountStatementValidator sut, CreateAccountStatementRequest command)
        {
            sut.ShouldNotHaveValidationErrorFor(s => s.AccountId, command);
        }

        [Test, AutoData]
        public void CreateAccountStatementCommandValidator_HasValidationErrors_WhenAccountIdIsInvalid(CreateAccountStatementValidator sut)
        {
            sut.ShouldHaveValidationErrorFor(s => s.AccountId, new CreateAccountStatementRequest());
        }

        [Test, AutoData]
        public void CreateAccountStatementCommandValidator_HasNoValidationErrors_WhenransactionIsValid(CreateAccountStatementValidator sut, CreateAccountStatementRequest command)
        {
            sut.ShouldNotHaveValidationErrorFor(s => s.Transactions, command);
        }

        [Test, AutoData]
        public void CreateAccountStatementCommandValidator_HasValidationErrors_WhenTransactionsAreEmpty(CreateAccountStatementValidator sut, CreateAccountStatementRequest command)
        {
            command.Transactions = new List<TransactionDto>();
            sut.ShouldHaveValidationErrorFor(s => s.Transactions, command);
        }

        [Test, AutoData]
        public void CreateAccountStatementCommandValidator_HasChildValidator_ForTransactionsList(CreateAccountStatementValidator sut)
        {
            sut.ShouldHaveChildValidator(s => s.Transactions, typeof(TransactionDtoValidator));
        }
    }
}
