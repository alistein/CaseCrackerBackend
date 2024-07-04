using CaseCracker.Domain.Entities;
using MongoDB.Driver;

namespace CaseCracker.Application.Common.Interfaces;

public interface IMongoDbContext
{
    public IMongoCollection<Onboarding> Onboardings { get; }
}