using ErrorOr;
using GymManagement.Domain.Admins;
using MediatR;

namespace GymManagement.Application.Admins.Commands.CreateAdmin;

public record CreateAdminCommand() : IRequest<ErrorOr<Admin>>;
