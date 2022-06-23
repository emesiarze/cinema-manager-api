using System;
using System.Collections.Generic;
using cinema_manager_api.Data;
using cinema_manager_api.Models;

namespace cinema_manager_api.Repositories
{
  public class ReservationsRepository : GenericRepository<Reservation>
  {
    public override List<Reservation> items
    {
      get
      {
        return ReservationsData.items;
      }
    }

    public override string AddItem(Reservation item)
    {
      try
      {
        Reservation potentiallyIdenticalItem = this.items.Find(reservation =>
        {
          TimeSpan reservationStartTime = DateTime.Now - reservation.startTime;
          TimeSpan minuteAgo = TimeSpan.FromMinutes(1);

          return reservation.seanseId.Equals(item.seanseId)
          && reservation.seatNumber.Equals(item.seatNumber)
          && !reservation.isPermanent
          && reservationStartTime < minuteAgo;
        });

        if (potentiallyIdenticalItem is null)
        {
          items.Add(item);
          return "success";
        }
        else
        {
          return "reservation_exists";
        }
      }
      catch
      {
        return "error";
      }
    }

    public override IEnumerable<Reservation> GetAllItems()
    {
      this.items.ForEach(item =>
      {
        User user = UsersData.items.Find(h => h.id.Equals(item.userId));
        Seanse seanse = SeansesData.items.Find(m => m.id.Equals(item.seanseId));
      });

      return items;
    }

    public override Reservation GetSingleItem(Guid id)
    {
      Reservation item = base.GetSingleItem(id);

      User user = UsersData.items.Find(h => h.id.Equals(item.userId));
      Seanse seanse = SeansesData.items.Find(m => m.id.Equals(item.seanseId));

      return item;
    }
  }
}