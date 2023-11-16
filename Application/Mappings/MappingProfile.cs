using Application.Features.Commands.Add;
using Application.Features.Commands.Delete;
using Application.Features.Commands.Update;
using Application.Models.Usuario;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUsuarioCommand, Usuarios>();
            CreateMap<UpUsuarioCommand, Usuarios>();
            CreateMap<DelUsuarioCommand, Usuarios>();
            CreateMap<Usuarios, UsuarioVm>();
        }
    }
}
