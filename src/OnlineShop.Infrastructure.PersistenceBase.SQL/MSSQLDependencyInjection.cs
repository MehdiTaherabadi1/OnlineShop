﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Infrastructure.PersistenceBase.SQL.DbContext;

namespace OnlineShop.Infrastructure.PersistenceBase.SQL;

public static class MSSQLDependencyInjection
{
    public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPersisterlayers, MSSQLPersister>();
        services.AddDbContext<ApplicationDbContext>(options =>
                                   options.UseSqlServer(
                                       configuration.GetConnectionString("DefaultConnection"),
                                       b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        return services;
    }
}
