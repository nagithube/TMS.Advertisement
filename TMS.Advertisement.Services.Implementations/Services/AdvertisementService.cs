using TMS.Advertisement.Services.Interfaces;

namespace TMS.Advertisement.Services.Implementations;

public class AdvertisementService : IAdvertisementService
{
    public List<Domain.Models.Advertisement> GenerateNewsForUser(Guid userId, string email)
    {
        throw new NotImplementedException();
    }

    public Task SaveNewsAsync(List<Domain.Models.Advertisement> newsItems)
    {
        throw new NotImplementedException();
    }
}