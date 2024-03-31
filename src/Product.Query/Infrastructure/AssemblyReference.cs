using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;

namespace Infrastructure;

public static class AssemblyReference
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //BsonSerializer.RegisterSerializer(new GuidSerializer());
        return services;
    }
}
