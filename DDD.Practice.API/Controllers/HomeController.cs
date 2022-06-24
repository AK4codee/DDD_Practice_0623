using DDD.Practice.API.Application.Commands.Message;
using DDD.Practice.API.Application.Queries;
using DDD.Practice.API.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Practice.API.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/service/1.0/study/get_messages")]
        public async Task<IActionResult> GetMessage([FromQuery] MessageQuery query, CancellationToken cancellationToken)
        {
            var res = new List<MessageVo>(await _mediator.Send(query, cancellationToken));
            return Ok(res);
        }


        [HttpPost]
        [Route("/service/1.0/study/add_messages")]
        public async Task<IActionResult> AddMessages([FromBody] AddMessageCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("/service/1.0/study/update_messages")]
        public async Task<IActionResult> UpdateMessages([FromBody] UpdateMessageCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("/service/1.0/study/delete_messages")]
        public async Task<IActionResult> DeleteMessages([FromBody] DeleteMessageCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
