using AccountCalculator.Commands;
using AccountCalculator.Dtos;
using AccountCalculator.Responses;
using AutoMapper;

namespace AccountCalculator.Mappings
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<CreateAccountStatementRequest, CreateAccountStatementCommand>();
            CreateMap<StatementDto, AccountStatementResponse>();
        }
    }
}
