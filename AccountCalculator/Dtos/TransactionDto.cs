using System;

namespace AccountCalculator.Dtos
{
    public class TransactionDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime BookingDate { get; set; }
        public string MerchantDetails { get; set; }
        public string CreditDebitIndicator { get; set; }
    }
}
