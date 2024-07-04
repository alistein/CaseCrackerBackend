using CaseCracker.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace CaseCracker.Infrastructure.Data.Configurations;

public class MongoDbMappings
{
    public static void Configure()
    {
        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
        
        ConventionRegistry.Register("camelCase", pack, t => true);

        BsonClassMap.RegisterClassMap<Onboarding>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty(c => c.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });
    }
}