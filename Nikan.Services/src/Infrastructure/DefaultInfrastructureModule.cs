using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Nikan.Services.BasicData.Core.CompanyAggregate;
using Nikan.Services.BasicData.Core.Interfaces;
using Nikan.Services.BasicData.Infrastructure.Data;
using Nikan.Services.BasicData.SharedKernel;
using Nikan.Services.BasicData.SharedKernel.Interfaces;
using Nikan.Services.BasicData.SharedKernel.Pagination;
using Module = Autofac.Module;

namespace Nikan.Services.BasicData.Infrastructure;

public class DefaultInfrastructureModule : Module
{
  private readonly List<Assembly> _assemblies = new();
  private readonly bool _isDevelopment;

  public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
  {
    _isDevelopment = isDevelopment;
    var coreAssembly =
      Assembly.GetAssembly(typeof(Company)); // TODO: Replace "Company" with any type from your Core project
    var infrastructureAssembly = Assembly.GetAssembly(typeof(StartupSetup));
    if (coreAssembly != null)
    {
      _assemblies.Add(coreAssembly);
    }

    if (infrastructureAssembly != null)
    {
      _assemblies.Add(infrastructureAssembly);
    }

    if (callingAssembly != null)
    {
      _assemblies.Add(callingAssembly);
    }
  }

  protected override void Load(ContainerBuilder builder)
  {
    if (_isDevelopment)
    {
      RegisterDevelopmentOnlyDependencies(builder);
    }
    else
    {
      RegisterProductionOnlyDependencies(builder);
    }

    RegisterCommonDependencies(builder);
  }

  private void RegisterCommonDependencies(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .As(typeof(IReadRepository<>))
      .InstancePerLifetimeScope();

    builder
      .RegisterType<Mediator>()
      .As<IMediator>()
      .InstancePerLifetimeScope();

    builder
      .RegisterType<DomainEventDispatcher>()
      .As<IDomainEventDispatcher>()
      .InstancePerLifetimeScope();

    builder.Register<ServiceFactory>(context =>
    {
      var c = context.Resolve<IComponentContext>();
      return t => c.Resolve(t);
    });


    var mediatrOpenTypes = new[]
    {
      typeof(IRequestHandler<,>), typeof(IRequestExceptionHandler<,,>), typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>)
    };

    foreach (var mediatrOpenType in mediatrOpenTypes)
    {
      builder
        .RegisterAssemblyTypes(_assemblies.ToArray())
        .AsClosedTypesOf(mediatrOpenType)
        .AsImplementedInterfaces();
    }

    builder.RegisterType<EmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();
  }

  private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
  {
    // TODO: Add development only services
  }

  private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
  {
    // TODO: Add production only services
    builder.RegisterType<SortHelper<Company>>().As<ISortHelper<Company>>().InstancePerLifetimeScope();
  }
}
