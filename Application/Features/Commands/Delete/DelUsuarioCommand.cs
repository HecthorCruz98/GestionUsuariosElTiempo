using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Delete
{
    public class DelUsuarioCommand : IRequest<int>
    {
        public DelUsuarioCommand(int? Id)
        {
            id = Id;
        }
        public int? id { get; set; }

    }
}
