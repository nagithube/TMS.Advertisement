namespace TMS.Advertisement.Services.Interfaces;

public interface IAdvertisementService
{
    List<Domain.Models.Advertisement> GenerateNewsForUser(Guid userId);
    Task SaveNewsAsync(List<Domain.Models.Advertisement> newsItems);
}