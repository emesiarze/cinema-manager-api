using System;
using System.Collections.Generic;
using cinema_manager_api.Data;
using cinema_manager_api.Models;

namespace Helpers
{
  public static class DataPopulator
  {
    public static void InitializeSeanses()
    {
      System.Diagnostics.Debug.WriteLine("Populating seanses");
      List<Hall> halls = HallsData.items;
      List<Movie> movies = MoviesData.items;

      Random rand = new Random();

      int minIndex = Math.Min(halls.Count, movies.Count);
      for (int i = 0; i < minIndex; i++)
      {
        DateTime date = DateTime.Now;
        date.AddDays(rand.Next(0, 5));
        date.AddHours(rand.Next(0, 5));
        date.AddMinutes(rand.Next(0, 59));
        SeansesData.items.Add(new Seanse(movies[i].id, halls[i].id, date));
      }
    }

    public static void InitializeReservations()
    {
      System.Diagnostics.Debug.WriteLine("Creating reservations");
      List<Seanse> seanses = SeansesData.items;
      List<User> users = UsersData.items;

      int minIndex = Math.Min(seanses.Count, users.Count);
      for (int i = 1; i < minIndex; i++)
      {
        ReservationsData.items.Add(new Reservation(users[i].id, seanses[i].id, i, DateTime.Now, false));
        ReservationsData.items.Add(new Reservation(users[i].id, seanses[i].id, i + 1, DateTime.Now, false));
      }
    }
  }
}