using Microsoft.EntityFrameworkCore;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.Infrastructure.Data;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Nikan.Services.BasicData.WebApi
{
  public static class SeedData
  {
    public static readonly Company TestCompanies = new Company("NIKAN", "88190", "info@nikan.com", "تهران", Guid.NewGuid());

    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var dbContext = new AppDbContext(
          serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
      {
        // Look for any TODO items.
        //if (dbContext.ToDoItems.Any())
        //{
        //  return;   // DB has been seeded
        //}

        PopulateTestData(dbContext);


      }
    }
    public static void PopulateTestData(AppDbContext dbContext)
    {
      foreach (var item in dbContext.Companies)
      {
        dbContext.Remove(item);
      }

      dbContext.SaveChanges();


      dbContext.Companies.Add(TestCompanies);

      dbContext.SaveChanges();
    }
  }
}


