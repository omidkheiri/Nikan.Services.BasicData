using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.Core.Interfaces;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Nikan.Services.BasicData.SharedKernel.Pagination;

namespace Nikan.Services.BasicData.Core.Services;
public class SearchCompanyService : ISearchCompanyService
{
  private readonly IRepository<Company> _repository;

  public SearchCompanyService(IRepository<Company> repository)
  {
    _repository = repository;
  }




}
