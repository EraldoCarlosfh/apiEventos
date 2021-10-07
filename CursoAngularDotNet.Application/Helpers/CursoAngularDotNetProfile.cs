using System;
using System.Linq;
using AutoMapper;
using CursoAngularDotNet.Application.Dtos;
using CursoAngularDotNet.Domain;
using CursoAngularDotNet.Domain.Identity;

namespace CursoAngularDotNet.Application.Helpers
{
    public class CursoAngularDotNetProfile : Profile
    {
        public CursoAngularDotNetProfile()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Palestrantes, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Palestrante).ToList());
                    }).ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.Eventos, opt => {
                    opt.MapFrom(src => src.PalestrantesEventos.Select(x => x.Evento).ToList());
                }).ReverseMap();
        }
    }
}
