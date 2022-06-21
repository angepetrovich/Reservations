using Microsoft.EntityFrameworkCore;

namespace Reservations.Models;

public class DemoContext : DbContext
{
    public DemoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ReservationModel> Events { get; set; }
    public DbSet<BiletModel> Bilets { get; set; }
}