using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
    {
        _IntilizeDbContext(services, configuration);
        return services;
    }
    private static void _IntilizeDbContext(IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<ApplicationContext>(options =>
        //                           options.UseSqlServer(
        //                               configuration.GetConnectionString("DefaultConnection"),
        //                               b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
    }

}
