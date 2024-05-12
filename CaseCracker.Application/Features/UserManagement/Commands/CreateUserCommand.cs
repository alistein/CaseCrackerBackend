using CaseCracker.Application.Features.UserManagement.Interfaces;
using CaseCracker.Domain.Entities;
using MediatR;

namespace CaseCracker.Application.Features.UserManagement.Commands;

public class CreateUserRequest : IRequest<bool>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

public class CreateUserCommand(IUserRepository userRepository) : IRequestHandler<CreateUserRequest, bool>
{
    public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await userRepository.AddAsync(new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = request.Password
        });

        return true;
    }
}