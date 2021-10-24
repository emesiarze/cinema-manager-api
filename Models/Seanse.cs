using System;

namespace CinemaManagerApi.Models
{
  public class Seanse : IDatabaseItem<Seanse>
  {
    public Seanse(int id, int movieId, int hallId, DateTime startTime)
    {
      this.id = id;
      this.movieId = movieId;
      this.hallId = hallId;
      this.startTime = startTime;
    }

    public int id { get; set; }
    public int movieId { get; set; }
    public int hallId { get; set; }
    public DateTime startTime { get; set; }

    public void Update(Seanse item)
    {
      this.movieId = item.movieId;
      this.hallId = item.hallId;
      this.startTime = item.startTime;
    }
  }
}