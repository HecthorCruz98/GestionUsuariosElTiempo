using Application.Contracts.Persistence;
using Application.Models.Usuario;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.List
{
    public class ListUsuarioQueryHandler : IRequestHandler<ListUsuarioQuery, List<UsuarioVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ListUsuarioQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ListUsuarioQueryHandler(
            IUnitOfWork unitOfWork,
            ILogger<ListUsuarioQueryHandler> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<UsuarioVm>> Handle(ListUsuarioQuery request, CancellationToken cancellationToken)
        {
            if (request.id != null)
            {
                var Entity = await _unitOfWork.Repository<Usuarios>().GetAsync(x => x.Id == request.id);
                var EntityVm = _mapper.Map<List<UsuarioVm>>(Entity);

                return EntityVm;

            }
            else
            {
                var Entity = await _unitOfWork.Repository<Usuarios>().GetAllAsync();
                var EntityVm = _mapper.Map<List<UsuarioVm>>(Entity);

                return EntityVm;

            }
        }
    }
}
