using System;
using System.Collections.Generic;

namespace AccountCalculator.Dtos
{
    public class StatementDto
    {
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalDebits { get; set; }
        public IEnumerable<DailyBalancesDto> EndOfDayBalances { get; set; }
    }
}
