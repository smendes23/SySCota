using AutoMapper;
using SysCota.Models;
using SysCota.ViewModel;

namespace IperonPrevCore.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

        }
    }
}
