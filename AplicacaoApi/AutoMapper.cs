using AutoMapper;
using DominioApi.Entidades;
using DominioApi.ModelosDtos;

namespace AplicacaoApi
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Boleto, BoletoDto>();
            CreateMap<BoletoDto, Boleto>();

            CreateMap<Banco, BancoDto>();
            CreateMap<BancoDto, Banco>();
        }
    }
}
