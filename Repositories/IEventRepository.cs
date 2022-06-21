using Reservations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Repositories;

public interface IEventRepository
{
    ReservationModel Get(int eventId);
    IQueryable<ReservationModel> GetAllActive();
    void Add(ReservationModel e);
    void Update(int eId, ReservationModel e);
    void Delete(int eId);
    
    BiletModel GetBilet(int biletId);
    IQueryable<BiletModel> GetAllActiveBilets();
    void AddBilet(BiletModel b);
    void UpdateBilet(int bId, BiletModel b);
    void DeleteBilet(int bId);
}