using ErrorOr;
using GymManagement.Domain.Admins;
using MediatR;

namespace GymManagement.Application.Admins.Queries.GetAdmin;

public record GetAdminQuery(Guid AdminId) : IRequest<ErrorOr<Admin>>;
