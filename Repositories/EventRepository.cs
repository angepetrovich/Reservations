using System.Linq;
using Reservations.Models;

namespace Reservations.Repositories;

public class EventRepository : IEventRepository
{
    private readonly DemoContext _context;
    public EventRepository(DemoContext context)
    {
        _context = context;
    }

    public ReservationModel Get(int eventId)
        => _context.Events.SingleOrDefault(x => x.EventId == eventId);

    public IQueryable<ReservationModel> GetAllActive()
        => _context.Events.OrderBy(x=> x.Name);

    public void Add(ReservationModel e)
    {
        _context.Events.Add(e);
        _context.SaveChanges();
    }

    public void Update(int eId, ReservationModel e)
    {
        var result = _context.Events.SingleOrDefault(x => x.EventId == eId);
        if (result != null)
        {
            result.Name = e.Name;
            result.DescriptionEvent = e.DescriptionEvent;
            result.AvailableSeats = e.AvailableSeats; 

            _context.SaveChanges();
        }
    }

    public void Delete(int eventId)
    {
        var result = _context.Events.SingleOrDefault(x => x.EventId == eventId);
        if (result != null)
        {
            _context.Events.Remove(result);
            _context.SaveChanges();
        }
    }
    
    
    public BiletModel GetBilet(int biletId)
        => _context.Bilets.SingleOrDefault(x => x.BiletId == biletId);
    

    public IQueryable<BiletModel> GetAllActiveBilets()
        => _context.Bilets.OrderBy(x=> x.NameBilet);

    public void AddBilet(BiletModel b)
    {
        _context.Bilets.Add(b);
        _context.SaveChanges();
    }

    public void UpdateBilet(int bId, BiletModel b)
    {
        var result = _context.Bilets.SingleOrDefault(x => x.BiletId == bId);
        if (result != null)
        {
            result.Email = b.Email;
            result.Number = b.Number;

            _context.SaveChanges();
        }
    }

    public void DeleteBilet(int biletId)
    {
        var result = _context.Bilets.SingleOrDefault(x => x.BiletId == biletId);
        if (result != null)
        {
            _context.Bilets.Remove(result);
            _context.SaveChanges();
        }
    }
}