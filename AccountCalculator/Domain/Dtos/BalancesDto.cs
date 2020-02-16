using AccountCalculator.Domain.Enum;

namespace AccountCalculator.Dtos
{
    public class BalancesDto
    {
        public decimal Amount { get; set; }
        public CreditDebitIndicator CreditDebitIndicator { get; set;}
        public string CreditLines { get; set; }
    }
}
