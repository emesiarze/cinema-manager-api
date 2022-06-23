using System.Collections.Generic;
using System.Linq;
using cinema_manager_api.Models;
using cinema_manager_api.Repositories;
using Xunit;

namespace Tests
{
  public class GenericRepositoryTester<T> where T : IDatabaseItem<T>
  {
    IRepository<T> Repository;
    List<T> Items;

    public GenericRepositoryTester(IRepository<T> repository, List<T> items)
    {
      this.Repository = repository;
      this.Items = items;
    }


    public void TestGetAllItems()
    {
      List<T> items = this.Repository.GetAllItems().ToList();
      Assert.NotEmpty(items);
      Assert.NotEqual(items.Count, 0);
    }


    public void TestGetSingleItem()
    {
      IDatabaseItem<T> baseItem = this.Items.First();
      T resultItem = Repository.GetSingleItem(baseItem.id);
      Assert.Equal(baseItem, resultItem);
    }


    public void TestAddItem(T item)
    {
      int sizeBefore = Items.Count;
      Repository.AddItem(item);
      int sizeAfter = Items.Count;

      Assert.Contains(item, Items);
      Assert.Equal(sizeAfter - sizeBefore, 1);
    }

    public void TestDeleteItem()
    {
      int sizeBefore = Items.Count;
      T baseItem = this.Items.First();
      Repository.DeleteItem(baseItem.id);
      int sizeAfter = Items.Count;

      Assert.DoesNotContain(baseItem, Items);
      Assert.Equal(sizeBefore - sizeAfter, 1);
    }
  }
}
