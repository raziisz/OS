using AutoMapper;
using OrdemServico.API.Dto;
using OrdemServico.API.Modelos;

namespace OrdemServico.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioListaDto>();
        }
    }
}