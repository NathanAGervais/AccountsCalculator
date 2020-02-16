using AccountCalculator.Dtos;
using AccountCalculator.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace AccountCalculator.Commands
{
    public class CreateAccountStatementRequest : IRequest<AccountStatementResponse>
    {
        public string AccountId { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayName { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public DateTime RequestDateTime { get; set; }
        public IdentifiersDto Identifiers { get; set; }
        public IDictionary<string, BalancesDto> Balances { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
