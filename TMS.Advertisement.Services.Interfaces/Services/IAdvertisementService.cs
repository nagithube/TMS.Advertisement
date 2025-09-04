namespace TMS.Advertisement.Services.Interfaces;

public interface IAdvertisementService
{
    List<Domain.Models.Advertisement> GenerateNewsForUser(Guid userId, string email);
    Task SaveNewsAsync(List<Domain.Models.Advertisement> newsItems);
}