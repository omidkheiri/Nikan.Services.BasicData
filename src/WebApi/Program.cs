using Ardalis.ListStartupServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nikan.Services.BasicData.Core;
using Nikan.Services.BasicData.Infrastructure;
using Nikan.Services.BasicData.Infrastructure.Data;
using Nikan.Services.BasicData.WebApi.V1.Endpoints.Mapper;
using Nikan.Services.BasicData.WebApi.V1.gPRC;
using Nikan.Services.BasicData.WebApi.V1.gPRC.Service;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext(connectionString);

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();
builder.Services.AddGrpc();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nikan Services Basic Data", Version = "v1" });
  c.EnableAnnotations();
});

// add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
builder.Services.Configure<ServiceConfig>(config =>
{
  config.Services = new List<ServiceDescriptor>(builder.Services);

  // optional - default path to view services is /listallservices - recommended to choose your own path
  config.Path = "/listservices";
});


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(
    new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var config = new MapperConfiguration(cfg =>
{
  cfg.AddProfile(new MappingProfile());

});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);




//builder.Services.ConfigureRepositoryWrapper();
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseDeveloperExceptionPage();
app.UseShowAllServicesMiddleware();
app.UseExceptionHandler("/swagger");
app.UseHsts();
//}
//else
//{
//  app.UseExceptionHandler("/swagger");

//}

app.UseRouting();

app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseCookiePolicy();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nikan Services Basic Data V1"));

app.UseEndpoints(endpoints =>
{
  endpoints.MapDefaultControllerRoute();
  endpoints.MapGrpcService<GrpcCompanyService>();
  endpoints.MapGet("/", async context =>
  {
    var endpointDataSource = context
      .RequestServices.GetRequiredService<EndpointDataSource>();
    await context.Response.WriteAsJsonAsync(new
    {
      results = endpointDataSource
        .Endpoints
        .OfType<RouteEndpoint>()
        .Where(e => e.DisplayName?.StartsWith("gRPC") == true)
        .Select(e => new
        {
          name = e.DisplayName,
          pattern = e.RoutePattern.RawText,
          order = e.Order
        })
        .ToList()
    });
  });

});

// Seed Database
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
    context.Database.EnsureCreated();
    // SeedData.Initialize(services);
  }
  catch (Exception ex)
  {
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
  }
}


app.Run();
