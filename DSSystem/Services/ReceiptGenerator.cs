namespace DSSystem.Services
{
  public class ReceiptGenerator
  {
    public List<itemStruct> itemGeneratorClass(int itemCount)
    {
      itemGeneratorClass itemGeneratorClass = new itemGeneratorClass();
      List<itemStruct> items = itemGeneratorClass.itemGenerator(itemCount);

      return items;
    }
    
  }

  
}

public class itemGeneratorClass
{
  List<String> itemNames = new List<String>()
  {
    "Tomato", "Onion", "Chillies", "Cat Food", "Coca cola", "Chicken"
  };
  List<int> itemPrice = new List<int>()
  {
    12,21,3,124,13,134,23,24,64,24,67,21,56,56
  };

  private Random gen = new Random();
  DateTime RandomDay()
  {
      DateTime start = new DateTime(1995, 1, 1);
      int range = (DateTime.Today - start).Days;           
      return start.AddDays(gen.Next(range));
  }
  internal List<itemStruct> itemGenerator(int ItemCount)
    {
      List <itemStruct>items = new List<itemStruct>();
      int i = 0;
      Random rnd = new();
      itemNames = ShufflerClass.Shuffle(itemNames,rnd).ToList();
      for(i = 0; i < ItemCount; i++)
      {
        if(i == itemNames.Count)
        {
            itemNames = ShufflerClass.Shuffle(itemNames,rnd).ToList();
        }
        items.Add(new itemStruct()
        {
          itemName = itemNames[rnd.Next(itemNames.Count - 1)],
          price = itemPrice[rnd.Next(itemNames.Count - 1)],
          quantity = rnd.Next(1,6),
          MFD = RandomDay(),
        });
      }
      return items;
    }
}

//random item picker of O(n), taken from https://stackoverflow.com/questions/1287567/is-using-random-and-orderby-a-good-shuffle-algorithm instead of using Default randomiser which is (n log n)
public static class ShufflerClass
{
  public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng) //method streams the items not the list itself.
  {
      T[] elements = source.ToArray();
      // Note i > 0 to avoid final pointless iteration
      for (int i = elements.Length-1; i > 0; i--)
      {
          // Swap element "i" with a random earlier element it (or itself)
          int swapIndex = rng.Next(i + 1);
          T tmp = elements[i];
          elements[i] = elements[swapIndex];
          elements[swapIndex] = tmp;
      }
      // Lazily yield (avoiding aliasing issues etc)
      foreach (T element in elements)
      {
          yield return element;
      }
  }
}