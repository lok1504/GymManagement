using ErrorOr;
using MediatR;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public record CreateSubscriptionCommand(
    SubscriptionType SubscriptionType, 
    Guid AdminId) : IRequest<ErrorOr<Subscription>>;