using AccountCalculator.Dtos;
using System;
using System.Collections.Generic;

namespace AccountCalculator.Responses
{
    public class AccountStatementResponse
    {
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalDebits { get; set; }
        public IEnumerable<DailyBalancesDto> EndOfDayBalances { get; set; }

    }
}
