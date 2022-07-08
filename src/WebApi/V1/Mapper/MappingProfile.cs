using AutoMapper;

using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.WebApi.V1.gPRC.Protos;
using Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.Mapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Company, CreateCompanyResponse>();
    CreateMap<Company, GetCompanyByIdResponse>();
    CreateMap<Company, UpdateCompanyResponse>();
    CreateMap<Company, GrpcCompanyModel>()
      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
      .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
      .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
      .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress));



  }
}
