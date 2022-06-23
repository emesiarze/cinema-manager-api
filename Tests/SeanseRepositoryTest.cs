using System.Linq;
using cinema_manager_api.Data;
using cinema_manager_api.Models;
using cinema_manager_api.Repositories;
using Helpers;
using Xunit;

namespace Tests
{
  public class SeansesRepositoryTest
  {
    GenericRepositoryTester<Seanse> tester;
    public SeansesRepositoryTest()
    {
      DataPopulator.InitializeSeanses();
      tester = new GenericRepositoryTester<Seanse>(
        new SeansesRepository(),
        SeansesData.items
      );
    }

    [Fact]
    public void TestSeansesRepository_CorrectlyGetAllItems()
    {
      tester.TestGetAllItems();
    }

    [Fact]
    public void TestSeansesRepository_CorrectlyGetSingleItem()
    {
      tester.TestGetSingleItem();
    }

    [Fact]
    public void TestSeansesRepository_CorrectlyAddItem()
    {
      Movie movie = MoviesData.items.First();
      Hall hall = HallsData.items.First();

      Seanse seanse = new Seanse(movie.id, hall.id, System.DateTime.Now);
      tester.TestAddItem(seanse);
    }

    [Fact]
    public void TestSeansesRepository_CorrectlyDeleteItem()
    {
      tester.TestDeleteItem();
    }
  }
}
