using Microsoft.EntityFrameworkCore;

namespace TMS.Advertisement.DataAccess.Contexts;

public class PostgreSqlTmsContext : DbContext
{
    public PostgreSqlTmsContext(DbContextOptions options) : base(options)
    {
    }

    protected PostgreSqlTmsContext()
    {
    }
    
    public DbSet<Domain.Models.Advertisement> Advertisements { get; set; }
}