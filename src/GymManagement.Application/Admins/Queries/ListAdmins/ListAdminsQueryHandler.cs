using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Admins;
using MediatR;

namespace GymManagement.Application.Admins.Queries.GetAdmins;

public class ListAdminsQueryHandler : IRequestHandler<ListAdminsQuery, ErrorOr<List<Admin>>>
{
    private readonly IAdminsRepository _adminsRepository;

    public ListAdminsQueryHandler(IAdminsRepository adminsRepository)
    {
        _adminsRepository = adminsRepository;
    }

    public async Task<ErrorOr<List<Admin>>> Handle(ListAdminsQuery request, CancellationToken cancellationToken)
    {
        return await _adminsRepository.GetAllAsync();
    }
}
