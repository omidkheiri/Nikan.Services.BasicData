using AutoMapper;

using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.WebApi.V1.Endpoints.CompanyEndPoints;

namespace Nikan.Services.BasicData.WebApi.V1.Endpoints.Mapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Company, CreateCompanyResponse>();
    CreateMap<Company, GetCompanyByIdResponse>();
    CreateMap<Company, UpdateCompanyResponse>();

  }
}
