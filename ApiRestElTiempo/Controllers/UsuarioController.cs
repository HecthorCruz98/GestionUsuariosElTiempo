using Application.Contracts.Persistence;
using Application.Features.Commands.Add;
using Application.Features.Commands.Delete;
using Application.Features.Commands.Update;
using Application.Features.Queries.List;
using Application.Models.Usuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiRestElTiempo.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioController(ILogger<UsuarioController> logger, IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<IEnumerable<UsuarioVm>>> Get(int? Id)
        {
            var query = await _mediator.Send(new ListUsuarioQuery(Id));
            return Ok(query);
        }

        [HttpPost("CrearUsuario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Create([FromBody] AddUsuarioCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("ActualizarUsuario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Update([FromBody] UpUsuarioCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("EliminarUsuario")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Delete([FromBody] DelUsuarioCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
