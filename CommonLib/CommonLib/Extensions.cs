using CommonLib.Other.DateTimeProvider;
using CommonLib.Other.JwtProvider;
using CommonLib.Other.PasswordHasher;
using Microsoft.Extensions.DependencyInjection;

namespace CommonLib;

public static class Extensions
{
    public static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        
        return services;
    }
}