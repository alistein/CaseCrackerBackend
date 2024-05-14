using CaseCracker.Application.Common.Interfaces;
using CaseCracker.Domain.Entities;
using MediatR;

namespace CaseCracker.Application.Features.UserManagement.Commands;

public class UpdateUserRequest : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class UpdateUserCommand(IUnitOfWork uow) : IRequestHandler<UpdateUserRequest,bool>
{
    public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        await uow.UserRepository.UpdateAsync(new User
        {
            Id = request.Id,
            Name = request.Name,
            Email = request.Email
        },nameof(User.PasswordHash));

        return true;
    }
}