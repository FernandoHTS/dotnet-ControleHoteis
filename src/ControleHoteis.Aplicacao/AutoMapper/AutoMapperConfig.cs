using AutoMapper;
using ControleHoteis.Aplicacao.ViewModels;
using ControleHoteis.Negocio.Models;

namespace ControleHoteis.Aplicacao.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Hotel, HotelViewModel>().ReverseMap();
            CreateMap<Quarto, QuartoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Foto, FotoViewModel>().ReverseMap();
        }

    }
}
