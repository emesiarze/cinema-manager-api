using System.Linq;
using cinema_manager_api.Data;
using cinema_manager_api.Models;
using cinema_manager_api.Repositories;
using Helpers;
using Xunit;

namespace Tests
{
  public class ReservationsRepositoryTest
  {
    GenericRepositoryTester<Reservation> tester;
    public ReservationsRepositoryTest()
    {
      tester = new GenericRepositoryTester<Reservation>(
        new ReservationsRepository(),
        ReservationsData.items
      );
    }

    [Fact]
    public void TestReservationsRepository_CorrectlyGetAllItems()
    {
      tester.TestGetAllItems();
    }

    [Fact]
    public void TestReservationsRepository_CorrectlyGetSingleItem()
    {
      tester.TestGetSingleItem();
    }

    [Fact]
    public void TestReservationsRepository_CorrectlyAddItem()
    {
      DataPopulator.InitializeSeanses();

      User user = UsersData.items.First();
      Seanse seanse = SeansesData.items.First();
      Reservation reservation = new Reservation(user.id, seanse.id, 2, System.DateTime.Now, false);
      tester.TestAddItem(reservation);
    }

    [Fact]
    public void TestReservationsRepository_CorrectlyDeleteItem()
    {
      tester.TestDeleteItem();
    }
  }
}
