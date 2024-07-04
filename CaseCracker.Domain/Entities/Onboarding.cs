using CaseCracker.Domain.Enums;

namespace CaseCracker.Domain.Entities;

public class Onboarding
{
    public string Id { get; set; }
    public OnboardingType OnboardingType { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public string ImagePath { get; set; }
    public bool IsDeleted { get; set; }
}