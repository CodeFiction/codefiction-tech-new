using Microsoft.EntityFrameworkCore;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data
{
  public sealed class SpaDbContext : DbContext
  {
    public SpaDbContext(DbContextOptions<SpaDbContext> options)
      : base(options)
    {
      Database.EnsureCreated();
    }   
  }
}
