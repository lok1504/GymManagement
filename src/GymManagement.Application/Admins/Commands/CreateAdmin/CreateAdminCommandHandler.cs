using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Admins;
using MediatR;

namespace GymManagement.Application.Admins.Commands.CreateAdmin;

public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, ErrorOr<Admin>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAdminsRepository _adminsRepository;

    public CreateAdminCommandHandler(IUnitOfWork unitOfWork, IAdminsRepository adminsRepository)
    {
        _unitOfWork = unitOfWork;
        _adminsRepository = adminsRepository;
    }

    public async Task<ErrorOr<Admin>> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = new Admin(userId: Guid.NewGuid());

        await _adminsRepository.AddAsync(admin);
        await _unitOfWork.CommitChangesAsync();

        return admin;
    }
}
