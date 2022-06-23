using cinema_manager_api.Data;
using cinema_manager_api.Models;
using cinema_manager_api.Repositories;
using Xunit;

namespace Tests
{
  public class MoviesRepositoryTest
  {
    GenericRepositoryTester<Movie> tester;
    public MoviesRepositoryTest()
    {
      tester = new GenericRepositoryTester<Movie>(
        new MoviesRepository(),
        MoviesData.items
      );
    }

    [Fact]
    public void TestMoviesRepository_CorrectlyGetAllItems()
    {
      tester.TestGetAllItems();
    }

    [Fact]
    public void TestMoviesRepository_CorrectlyGetSingleItem()
    {
      tester.TestGetSingleItem();
    }

    [Fact]
    public void TestMoviesRepository_CorrectlyAddItem()
    {
      Movie movie = new Movie("Let Ji", "Burning up", 105);
      tester.TestAddItem(movie);
    }

    [Fact]
    public void TestMoviesRepository_CorrectlyDeleteItem()
    {
      tester.TestDeleteItem();
    }
  }
}
