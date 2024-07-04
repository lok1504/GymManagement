using ErrorOr;
using GymManagement.Domain.Admins;
using MediatR;

namespace GymManagement.Application.Admins.Queries.GetAdmins;

public record ListAdminsQuery() : IRequest<ErrorOr<List<Admin>>>;