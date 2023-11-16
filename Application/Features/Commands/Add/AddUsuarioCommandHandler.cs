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

namespace Application.Features.Commands.Add
{
    public class AddUsuarioCommandHandler : IRequestHandler<AddUsuarioCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AddUsuarioCommandHandler> _logger;

        public AddUsuarioCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AddUsuarioCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            int resp = 0;
            if (request != null)
            {
                var Entity = _mapper.Map<Usuarios>(request);
                var EntityAdd = await _unitOfWork.Repository<Usuarios>().AddAsync(Entity);
                _logger.LogInformation($"El usuario fue creado con el id {EntityAdd.Id}");

                return resp = 1;
            }
            else
            {
                return resp = 0;
            }
        }
    }
}
