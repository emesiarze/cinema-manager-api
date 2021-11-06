using System;
using System.Collections.Generic;
using CinemaManagerApi.Models;
using CinemaManagerApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagerApi.Controllers
{
  public class ReservationsController : GenericController<Reservation>
  {
    public ReservationsController(IRepository<Reservation> repository) : base(repository) { }

    [HttpGet("allBySeanse")]
    public Response<IEnumerable<Reservation>> GetAllItemsBySeanse(Guid seanseId)
    {
      System.Diagnostics.Debug.WriteLine("Getting reservations by seanse");
      Response<IEnumerable<Reservation>> response = new Response<IEnumerable<Reservation>>();

      try
      {
        List<Reservation> items = new List<Reservation>(base.repository.GetAllItems());
        IEnumerable<Reservation> matchingReservations = items.FindAll(items => items.seanseId.Equals(seanseId));
        response.data = matchingReservations;
        response.isSuccess = true;
      }
      catch
      {
        response.isSuccess = false;
        response.errorMessage = "error";
      }

      return response;
    }
  }
}