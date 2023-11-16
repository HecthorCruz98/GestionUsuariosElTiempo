using Application.Models.Usuario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.List
{
    public class ListUsuarioQuery : IRequest<List<UsuarioVm>>
    {
        public ListUsuarioQuery(int? Id)
        {
            id = Id;
        }
        public int? id { get; set; }
    }
}
