using AccountCalculator.Commands;
using AccountCalculator.Dtos;
using AccountCalculator.Repositories;
using AccountCalculator.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AccountCalculator.Domain.Enum;

namespace AccountCalculator.Handlers.Commands
{
    public class CreateAccountStatementHandler : IRequestHandler<CreateAccountStatementRequest, AccountStatementResponse>
    {
        readonly IStatementsRepository _statementsRepository;
        readonly IMapper _mapper;
        public CreateAccountStatementHandler(IStatementsRepository statementsRepository, IMapper mapper)
        {
            _statementsRepository = statementsRepository;
            _mapper = mapper;
        }

        public async Task<AccountStatementResponse> Handle(CreateAccountStatementRequest request, CancellationToken cancellationToken)
        {
            
            var balance = CalculateStartingBalance(request.Balances["Current"]);
            var validTransactions = request.Transactions.Where(transaction => transaction.BookingDate.Date <= request.RequestDateTime.Date).ToList();

            var totalCredits = SumAmount(validTransactions, transaction => transaction.CreditDebitIndicator == CreditDebitIndicator.Credit);
            var totalDebits = SumAmount(validTransactions, transaction => transaction.CreditDebitIndicator == CreditDebitIndicator.Debit);

            var transactionsByDay = validTransactions.GroupBy(validTransaction => validTransaction.BookingDate.Date);
            var endOfDayBalances = new List<DailyBalancesDto>();
            foreach (var dailyTransaction in transactionsByDay)
            {
                balance = dailyTransaction.Aggregate(balance, (current, tran) => tran.CreditDebitIndicator == CreditDebitIndicator.Credit
                    ? current + tran.Amount
                    : current - tran.Amount);
                endOfDayBalances.Add(new DailyBalancesDto { Balance = balance, Date = dailyTransaction.Key });
            }

            var statementDto = new StatementDto { EndOfDayBalances = endOfDayBalances, TotalCredits = totalCredits, TotalDebits = totalDebits, AccountId = request.AccountId };

            var statement = await _statementsRepository.AddAsync(statementDto);

            return _mapper.Map<AccountStatementResponse>(statement);

        }

        decimal CalculateStartingBalance(BalancesDto currentBalanceDto)
        {
            
            var startingBalance = currentBalanceDto.Amount;
            if (currentBalanceDto.CreditDebitIndicator == CreditDebitIndicator.Debit)
            {
                startingBalance = startingBalance * -1;
            }

            return startingBalance;
        }

        decimal SumAmount(IEnumerable<TransactionDto> transactions, Func<TransactionDto, bool> whereParam) => transactions.Where(whereParam).Sum(transaction => transaction.Amount);
    }
}
