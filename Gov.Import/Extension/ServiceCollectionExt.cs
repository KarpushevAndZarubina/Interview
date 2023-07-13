using System.Reflection;

using Gov.Import.Data;
using Gov.Import.Services;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using NLog.Extensions.Logging;

namespace Gov.Import.Extension;
public static class ServiceCollectionExt
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddLogging(n => n.AddNLog());
        services.AddSingleton<IConfiguration>(f => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddDbContextFactory<EntityContext>();
        services.AddTransient<IRepository<FapData>, DbRepository<FapData, EntityContext>>();
        services.AddHostedService<HostingService>();

        return services;
    }
}
