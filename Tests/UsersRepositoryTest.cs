using cinema_manager_api.Data;
using cinema_manager_api.Models;
using cinema_manager_api.Repositories;
using Xunit;

namespace Tests
{
  public class UsersRepositoryTest
  {
    GenericRepositoryTester<User> tester;
    public UsersRepositoryTest()
    {
      tester = new GenericRepositoryTester<User>(
        new UsersRepository(),
        UsersData.items
      );
    }

    [Fact]
    public void TestUsersRepository_CorrectlyGetAllItems()
    {
      tester.TestGetAllItems();
    }

    [Fact]
    public void TestUsersRepository_CorrectlyGetSingleItem()
    {
      tester.TestGetSingleItem();
    }

    [Fact]
    public void TestUsersRepository_CorrectlyAddItem()
    {
      User user = new User("George Smith", "geosmith", "password", false);
      tester.TestAddItem(user);
    }

    [Fact]
    public void TestUsersRepository_CorrectlyDeleteItem()
    {
      tester.TestDeleteItem();
    }
  }
}
