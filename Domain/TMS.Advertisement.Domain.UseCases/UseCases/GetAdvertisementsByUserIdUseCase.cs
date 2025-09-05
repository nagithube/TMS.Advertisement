using Microsoft.EntityFrameworkCore;
using TMS.Advertisement.DataAccess.Contexts;

namespace TMS.Advertisement.Domain.UseCases;

public class GetAdvertisementsByUserIdUseCase
{
    private readonly PostgreSqlTmsContext _context;

    public GetAdvertisementsByUserIdUseCase(PostgreSqlTmsContext context) =>
        _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<List<Models.Advertisement>> ExecuteAsync(Guid userId, CancellationToken cancellationToken) =>
        await _context.Advertisements
            .Where(a => a.UserId == userId)
            .ToListAsync(cancellationToken);
}