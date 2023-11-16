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

namespace Application.Features.Commands.Update
{
    public class UpUsuarioCommandHandler : IRequestHandler<UpUsuarioCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpUsuarioCommandHandler> _logger;

        public UpUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpUsuarioCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(UpUsuarioCommand request, CancellationToken cancellationToken)
        {
            var verifyData = await _unitOfWork.Repository<Usuarios>().GetFirstOrDefaultAsync(x => x.Id == request.Id);

            int resp = 0;

            if (verifyData != null)
            {
                verifyData.Nombre = request.Nombre;
                verifyData.CorreoElectronico = request.CorreoElectronico;
                verifyData.Contrasena = request.Contrasena;

                await _unitOfWork.Repository<Usuarios>().UpdateAsync(verifyData);

                _logger.LogInformation($"El usuario con el id {verifyData.Id} fue actualizado correctamente ");


                return resp = 1;

            }
            else
            {
                return resp = 0;
            }
        }
    }
}
