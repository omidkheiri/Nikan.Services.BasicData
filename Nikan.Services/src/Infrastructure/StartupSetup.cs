using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nikan.Services.BasicData.Infrastructure.Data;

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
