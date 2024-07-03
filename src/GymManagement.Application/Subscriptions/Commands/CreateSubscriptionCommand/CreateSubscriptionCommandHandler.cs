using ErrorOr;
using MediatR;
using GymManagement.Domain.Subscriptions;
using GymManagement.Application.Common.Interfaces;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscriptionCommand;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;
    //private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository)
    {
        _subscriptionsRepository = subscriptionsRepository;
        //_unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            SubscriptionType = request.SubscriptionType,
        };

        await _subscriptionsRepository.AddSubscriptionAsync(subscription);
        //await _unitOfWork.CommitChangesAsync();

        return subscription;
    }
}
