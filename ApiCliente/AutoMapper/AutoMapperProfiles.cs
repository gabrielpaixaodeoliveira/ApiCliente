using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace ApiCliente.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteSaidaDTO>()
            .ForMember(x => x.Id, opt => opt.MapFrom(o => o.IdCliente));
        }
    }
}