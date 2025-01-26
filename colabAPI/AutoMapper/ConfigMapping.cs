using AutoMapper;
using colabAPI.Business.DTOs.Request;
using colabAPI.Business.DTOs.Response;
using colabAPI.Business.Models.Entities;

namespace colabAPI.AutoMapper;

public class ConfigMapping : Profile
{
    public ConfigMapping()
    {
        CreateMap<Financiador, FinanciadorRequestDTO>()
            .ReverseMap();
        CreateMap<Financiador, FinanciadorResponseDTO>()
            .ReverseMap();
    }
}