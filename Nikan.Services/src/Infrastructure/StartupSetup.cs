using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.Infrastructure.Data;
using Nikan.Services.BasicData.SharedKernel.Pagination;

namespace Nikan.Services.BasicData.Infrastructure;

public static class StartupSetup
{
  public static void AddDbContext(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<AppDbContext>(options =>
      options.UseNpgsql(connectionString));
    // will be created in web project root

  }



}
