using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using TMS.Advertisement.Services.Interfaces;
using TMS.Contracts.Events;

namespace TMS.Advertisement.Consumers;

public class ConfirmationRegistrationConsumer : IConsumer<UserLoggedInEvent>
{
    private readonly IServiceProvider _provider;
    private IAdvertisementService? _advertisementService;

    public ConfirmationRegistrationConsumer(IServiceProvider provider)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));

        _advertisementService = _provider.GetService<IAdvertisementService>();
    }

    public async Task Consume(ConsumeContext<UserLoggedInEvent> context)
    {
        if (context.Message.UserId == null)
            return;

        var advertisements = await _advertisementService.GenerateNewsForUser(context.Message.UserId);
        await _advertisementService.SaveNewsAsync(advertisements);
    }
}