using AccountCalculator.Dtos;
using System.Threading.Tasks;

namespace AccountCalculator.Repositories
{
    public interface IStatementsRepository
    {
        Task<StatementDto> AddAsync(StatementDto statement);
    }
}
