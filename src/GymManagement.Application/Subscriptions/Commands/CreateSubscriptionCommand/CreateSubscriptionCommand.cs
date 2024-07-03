using ErrorOr;
using MediatR;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscriptionCommand;

public record CreateSubscriptionCommand(
    string SubscriptionType, 
    Guid AdminId) : IRequest<ErrorOr<Subscription>>;