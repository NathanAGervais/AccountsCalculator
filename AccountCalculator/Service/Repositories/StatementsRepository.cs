using AccountCalculator.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountCalculator.Repositories
{
    public class StatementsRepository : IStatementsRepository
    {
        readonly List<StatementDto> _statements = new List<StatementDto>();

        public Task<StatementDto> AddAsync(StatementDto statement)
        {
            statement.Id = Guid.NewGuid();
            _statements.Add(statement);
            return Task.FromResult(statement);
        }
    }
}
