using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Domain;
using CaseCracker.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CaseCracker.Infrastructure.Data.Context;

public class MongoDbContext : IMongoDbContext
{
    public IMongoCollection<Onboarding> Onboardings { get; }

    public MongoDbContext(IOptions<MongoSettings> mongoSettings)
    {
        var client = new MongoClient(mongoSettings.Value.ConnectionUri);

        var mongoDatabase = client.GetDatabase(mongoSettings.Value.DatabaseName);

        Onboardings = mongoDatabase.GetCollection<Onboarding>("Onboardings");
    }
}