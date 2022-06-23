using cinema_manager_api.Data;
using cinema_manager_api.Models;
using cinema_manager_api.Repositories;
using Xunit;

namespace Tests
{
  public class HallsRepositoryTest
  {
    GenericRepositoryTester<Hall> tester;
    public HallsRepositoryTest()
    {
      tester = new GenericRepositoryTester<Hall>(
        new HallsRepository(),
        HallsData.items
      );
    }

    [Fact]
    public void TestHallsRepository_CorrectlyGetAllItems()
    {
      tester.TestGetAllItems();
    }

    [Fact]
    public void TestHallsRepository_CorrectlyGetSingleItem()
    {
      tester.TestGetSingleItem();
    }

    [Fact]
    public void TestHallsRepository_CorrectlyAddItem()
    {
      Hall hall = new Hall("10");
      tester.TestAddItem(hall);
    }

    [Fact]
    public void TestHallsRepository_CorrectlyDeleteItem()
    {
      tester.TestDeleteItem();
    }
  }
}
