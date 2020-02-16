using AccountCalculator.Dtos;
using AutoFixture.NUnit3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountCalculator.Tests.Repositories
{
    [TestFixture]
    public class StatementRepositoryTests
    {
        [Test, AutoData]
        public async Task AddAsync_ReturnsSavedExternalLinkObject_WhenValidDataIsSupplied(string accountId, DateTime RequestDateTime, IDictionary<string, BalancesDto> balances, List<TransactionDto> transactions)
        {

        }
    }
}
