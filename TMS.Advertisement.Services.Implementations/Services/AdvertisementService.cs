using TMS.Advertisement.DataAccess.Contexts;
using TMS.Advertisement.Services.Interfaces;

namespace TMS.Advertisement.Services.Implementations;

public class AdvertisementService : IAdvertisementService
{
    private readonly PostgreSqlTmsContext _context;

    public AdvertisementService(PostgreSqlTmsContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Domain.Models.Advertisement>> GenerateNewsForUser(Guid userId) =>
    [
        new()
        {
            Title = "Добро пожаловать!",
            Content = "Привет! Рады видеть тебя снова.",
            UserId = userId
        },

        new()
        {
            Title = "Специальное предложение",
            Content = "Получите 10% скидку на первый заказ!",
            UserId = userId
        },

        new()
        {
            Title = "Новинки",
            Content = "Ознакомьтесь с новыми товарами в нашем каталоге.",
            UserId = userId
        }
    ];

    public async Task SaveNewsAsync(List<Domain.Models.Advertisement> newsItems)
    {
        await _context.Advertisements.AddRangeAsync(newsItems);
        await _context.SaveChangesAsync();
    }
}