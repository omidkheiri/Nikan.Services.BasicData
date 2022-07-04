using AutoMapper;
using Nikan.Services.BasicData.Core.AccountAggregate;
using Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.Mapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Company, CreateCompanyResponse>();
    CreateMap<Company, GetCompanyByIdResponse>();

  }
}
