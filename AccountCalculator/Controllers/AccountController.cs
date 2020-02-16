using AccountCalculator.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;

namespace AccountCalculator.Controllers
{
    [Route("api")]
    public class AccountController: ApiControllerBase
    {
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateBalances([FromBody] CreateAccountStatementRequest request)
        {
            var command = _mapper.Map<CreateAccountStatementCommand>(request);
            return Ok(await CommandAsync(command));
        }

    }
}