using AccountCalculator.Dtos;
using AccountCalculator.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace AccountCalculator.Commands
{
    public class CreateEndOfDaysBalanceCalculationCommand : IRequest<CalculatedBalancesResponse>
    {
        public string AccountId { get; set; }
        public DateTime RequestDateTime { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}
