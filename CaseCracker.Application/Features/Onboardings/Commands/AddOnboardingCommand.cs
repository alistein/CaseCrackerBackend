using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Domain.Entities;
using CaseCracker.Domain.Enums;
using MediatR;

namespace CaseCracker.Application.Features.Onboardings.Commands;

public class AddOnboardingRequest : IRequest<bool>
{
    public OnboardingType OnboardingType { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public string ImagePath { get; set; }
}

public class AddOnboardingCommand(IMongoDbContext mongoDbContext) : IRequestHandler<AddOnboardingRequest, bool>
{
    public async Task<bool> Handle(AddOnboardingRequest request, CancellationToken cancellationToken)
    {
        await mongoDbContext.Onboardings.InsertOneAsync(new Onboarding
        {
            Title = request.Title,
            Description = request.Description,
            ImagePath = request.ImagePath,
            Subtitle = request.Subtitle,
            Order = request.Order,
            OnboardingType = request.OnboardingType,
        }, cancellationToken: cancellationToken);

        return true;
    }
}