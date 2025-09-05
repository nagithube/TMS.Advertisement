using Microsoft.AspNetCore.Mvc;
using TMS.Advertisement.DataAccess.Contexts;
using TMS.Advertisement.Domain.UseCases;

namespace TMS.Advertisement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementsController : ControllerBase
{
    private readonly PostgreSqlTmsContext _context;
    private readonly GetAdvertisementsByUserIdUseCase _getAdvertisementsByUserIdUseCase;

    public AdvertisementsController(
        PostgreSqlTmsContext context,
        GetAdvertisementsByUserIdUseCase getAdvertisementsByUserIdUseCase)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

        _getAdvertisementsByUserIdUseCase =
            getAdvertisementsByUserIdUseCase ??
            throw new ArgumentNullException(nameof(getAdvertisementsByUserIdUseCase));
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<ActionResult<List<Domain.Models.Advertisement>>> GetAdvertisementsByUserId(Guid userId)
    {
        var advertisements = _getAdvertisementsByUserIdUseCase.ExecuteAsync(userId, CancellationToken.None);

        return Ok(advertisements);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Domain.Models.Advertisement>> GetAdvertisement(Guid id)
    {
        var advertisement = await _context.Advertisements.FindAsync(id);
            
        if (advertisement == null)
            return NotFound();

        return Ok(advertisement);
    }
}