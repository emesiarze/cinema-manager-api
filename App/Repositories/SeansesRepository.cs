using System;
using System.Collections.Generic;
using cinema_manager_api.Data;
using cinema_manager_api.Models;

namespace cinema_manager_api.Repositories
{
  public class SeansesRepository : GenericRepository<Seanse>
  {
    public override List<Seanse> items
    {
      get
      {
        return SeansesData.items;
      }
    }

    override public IEnumerable<Seanse> GetAllItems()
    {
      this.items.ForEach(item =>
      {
        Hall hall = HallsData.items.Find(h => h.id.Equals(item.hallId));
        Movie movie = MoviesData.items.Find(m => m.id.Equals(item.movieId));

        item.hall = hall;
        item.movie = movie;
      });

      return items;
    }

    override public Seanse GetSingleItem(Guid id)
    {
      Seanse item = base.GetSingleItem(id);
      Hall hall = HallsData.items.Find(h => h.id.Equals(item.hallId));
      Movie movie = MoviesData.items.Find(m => m.id.Equals(item.movieId));

      item.hall = hall;
      item.movie = movie;

      return item;
    }
  }
}