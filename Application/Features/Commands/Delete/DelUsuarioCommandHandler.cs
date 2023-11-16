using Application.Contracts.Persistence;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Delete
{
    public class DelUsuarioCommandHandler : IRequestHandler<DelUsuarioCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DelUsuarioCommandHandler> _logger;
        private readonly IMapper _mapper;


        public DelUsuarioCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<DelUsuarioCommandHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> Handle(DelUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.id.Equals(null))
            {
                var Delete = await _unitOfWork.Repository<Usuarios>().GetFirstOrDefaultAsync(x => x.Id == request.id);

                if (Delete != null)
                {
                    await _unitOfWork.Repository<Usuarios>().DeleteAsync(Delete);
                    _logger.LogInformation($"El usuario con el id {request.id} fue eliminado");

                    return 1;
                }
                else
                {
                    _logger.LogInformation($"El usuario con el id {request.id} no existe");

                    return 0;

                }

            }
            else
            {
                return 0;

            }
        }
    }
}
