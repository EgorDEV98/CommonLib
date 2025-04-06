using CommonLib.EFCore.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommonLib.EFCore.Extensions;

public static class DbContextExtensions
{
    /// <summary>
    /// Добавляет 
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configuration">Конфигурация</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IServiceCollection AddPostgresDbContext<T>(this IServiceCollection serviceCollection, IConfiguration configuration) where T : DbContext
    {
        var connectionString = configuration
            .GetSection(nameof(PostgresSettings))
            .GetSection(nameof(PostgresSettings.ConnectionString)).Value;
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("Postgres ConnectionString is null or Empty");
        
        serviceCollection.AddDbContext<T>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });
        return serviceCollection;
    }
    
    /// <summary>
    /// Провести миграции
    /// </summary>
    /// <param name="services"></param>
    /// <typeparam name="T"></typeparam>
    public static async Task ApplyMigrationAsync<T>(this IServiceProvider services) where T : DbContext
    {
        await using var scope = services.CreateAsyncScope();
        var dbContextReserve = scope.ServiceProvider.GetRequiredService<T>();
        try
        {
            await dbContextReserve.Database.MigrateAsync();
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Exception {nameof(T)}: {exception.Message}");
            Console.WriteLine($"Ошибка: при создании базы данных {exception.Message}");
            Console.WriteLine($"{exception?.InnerException?.Message}");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Выход из приложения exit(1), сервер ASPNET не запущен!");
            Environment.Exit(333);
        }
    }
}