using System.Collections.Generic;
using cinema_manager_api.Data;
using cinema_manager_api.Models;

namespace cinema_manager_api.Repositories
{
  public class MoviesRepository : GenericRepository<Movie>
  {
    public override List<Movie> items
    {
      get
      {
        return MoviesData.items;
      }
    }
  }
}