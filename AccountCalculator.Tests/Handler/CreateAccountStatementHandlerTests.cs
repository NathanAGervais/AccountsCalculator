using AccountCalculator.Commands;
using AccountCalculator.Dtos;
using AccountCalculator.Handlers.Commands;
using AccountCalculator.Repositories;
using AccountCalculator.Tests.Attributes;
using AutoFixture.NUnit3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AccountCalculator.Domain.Enum;

namespace AccountCalculator.Tests.Handler
{
    [TestFixture]
    public class CreateAccountStatementHandlerTests
    {
        [Test, AutoMoqDataAttribute]
        public async Task Handle_CalculatesTotalCredits_WuthValidConfig([Frozen] IStatementsRepository statementsRepository, CreateAccountStatementHandler sut)
        { 
            var balances = new Dictionary<string, BalancesDto>
            {
                {
                    "Current",
                    new BalancesDto
                    {
                        Amount = 100, CreditDebitIndicator = CreditDebitIndicator.Credit, CreditLines = null
                    }
                }
            };
            var command = new CreateAccountStatementRequest
            {
                AccountId = "account1", 
                Balances = balances, 
                RequestDateTime = DateTime.Now, 
                Transactions = new List<TransactionDto>
                {
                    new TransactionDto
                    {
                        Amount = 500, 
                        CreditDebitIndicator = CreditDebitIndicator.Credit, 
                        Status = "Booked", 
                        BookingDate = DateTime.Today.AddDays(-1)
                    },
                    new TransactionDto
                    {
                        Amount = 500,
                        CreditDebitIndicator = CreditDebitIndicator.Debit,
                        Status = "Booked",
                        BookingDate = DateTime.Today.AddDays(-1)
                    }
                }
            };
            var result = await sut.Handle(command, CancellationToken.None );

            Assert.AreEqual(result.TotalCredits, 1000);
        }
    }
}
