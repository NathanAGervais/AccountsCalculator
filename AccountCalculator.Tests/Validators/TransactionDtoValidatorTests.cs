using AccountCalculator.Dtos;
using AccountCalculator.Validation;
using AutoFixture.NUnit3;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace AccountCalculator.Tests
{
    [TestFixture]
    public class TransactionDtoValidatorTests
    {
        [Test, AutoData]
        public void TransactionDtoValidator_HasNoValidationErrors_WhenStatusIsValid(TransactionDtoValidator sut, TransactionDto dto)
        {
            sut.ShouldNotHaveValidationErrorFor(s => s.Status, dto);
        }

        [Test, AutoData]
        public void TransactionDtoValidator_HasNoValidationErrors_WhenStatusIsInvalid(TransactionDtoValidator sut)
        {

            sut.ShouldHaveValidationErrorFor(s => s.Status, new TransactionDto());
        }

        [Test, AutoData]
        public void TransactionDtoValidator_HasNoValidationErrors_WhenCreditDebitIndicatorIsValid(TransactionDtoValidator sut, TransactionDto dto)
        {
            sut.ShouldNotHaveValidationErrorFor(s => s.CreditDebitIndicator, dto);
        }

        [Test, AutoData]
        public void TransactionDtoValidator_HasNoValidationErrors_WhenCreditDebitIndicatorIsInvalid(TransactionDtoValidator sut)
        {

            sut.ShouldHaveValidationErrorFor(s => s.CreditDebitIndicator, new TransactionDto());
        }
    }
}