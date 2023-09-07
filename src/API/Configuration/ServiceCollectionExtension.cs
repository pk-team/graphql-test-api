using System.Reflection;
using Application.Command;
using Application.Query;

namespace API.Configuration;

public static class ServiceCollectionExtension {

    // ICommandHandler
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services) {
        Assembly assembly = typeof(ICommandHandler).Assembly;
        IEnumerable<Type> types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(ICommandHandler)));

        foreach (Type type in types) {
            _ = services.AddTransient(type);
        }

        return services;
    }
    // IQueryHandler
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services) {
        Assembly assembly = typeof(IQueryHandler).Assembly;
        IEnumerable<Type> types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(typeof(IQueryHandler)));

        foreach (Type type in types) {
            _ = services.AddTransient(type);
        }

        return services;
    }

}