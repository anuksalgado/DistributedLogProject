namespace DSShared.Generators
{
  public class ReceiptGenerator
  {
    public List<itemStruct> itemGeneratorClass(int itemCount)
    {
      itemGeneratorClass itemGeneratorClass = new itemGeneratorClass();
      List<itemStruct> items = itemGeneratorClass.itemGenerator(itemCount);

      return items;
    }

    public (List<ReceiptStruct> receipts, List<itemStruct> items) receiptGeneratorClass(int receiptCount, int itemCount)
    {
      ReceiptGeneratorClass receiptGeneratorClass= new ReceiptGeneratorClass();
      var (receipts, items) = receiptGeneratorClass.receiptGenerator(receiptCount, itemCount);
      return (receipts,items);
    }
    
  }

  
}

public class ReceiptGeneratorClass
{
  //class to generate receipts
  private Random gen = new Random();
  DateTime RandomDay()
  {
      DateTime start = new DateTime(2020, 1, 1);
      int range = (DateTime.Today - start).Days;           
      return start.AddDays(gen.Next(range));
  }
  internal (List<ReceiptStruct> receipts, List<itemStruct> items) receiptGenerator(int reiceiptCount, int itemCount)
  {
    List<String> names = new List<String>()
    {
      "Anuk", "Palmer", "Jokovic", "Hazard", "Enzo", "Caicedo", "Lavia", "Cech", "Drogba", "Lamps", "Carvalho",
      "Mount", "Kante", "Reece", "Silva", "Chilwell", "Sterling", "Gusto", "Nkunku", "Broja",
      "Badiashile", "Gallagher", "Fofana", "James", "Petrov"
    };
    
    List <ReceiptStruct>receipts = new List<ReceiptStruct>();
    List <itemStruct>itemsCollection = new List<itemStruct>();
    List<itemStruct> allItems = new();
    Random rnd = new();
    var itemGen = new itemGeneratorClass();
    names = ShufflerClass.Shuffle(names,rnd).ToList(); //shuffling names
    int itemIdCounter = 1;
    for(int i = 0; i < reiceiptCount; i++)
    {
      if(i == names.Count)
      {
        names = ShufflerClass.Shuffle(names,rnd).ToList(); //shuffling names
      }
      var receiptID = ReceiptIDGenerator.GenerateID();
      var items = itemGen.itemGenerator(itemCount).Select(item => new itemStruct //making new itemStruct with item (generated from class) and id & receiptStruct added to it
      {
        Id = itemIdCounter++, //adding to generated itemStruct
        itemName = item.itemName,
        price = item.price,
        quantity = item.quantity,
        MFD = item.MFD,
        ReceiptStructReceiptID = receiptID //adding to generated itemStruct
    }).ToList();
      allItems.AddRange(items);
      receipts.Add(new ReceiptStruct()
        {
          puchaseDate = RandomDay(),
          cusName = names[rnd.Next(names.Count - 1)], //setting the cusName to a random index within shuffled names
          ReceiptID = receiptID,
          items = items
        });
    }
    return (receipts, allItems);
    
    /*
    public class ReceiptStruct
{
  public List<itemStruct> items { get; set; } = new List<itemStruct>(); //receipt can hold multiple items
  public DateTime puchaseDate {get;set;}
  public string cusName {get;set;}
}*/
  }
}
public class itemGeneratorClass
{
  //Class generates items
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
      DateTime start = new DateTime(2020, 1, 1);
      int range = (DateTime.Today - start).Days;           
      return start.AddDays(gen.Next(range));
  }
  //function which takes in an itemCount to generate a specific number of items as per itemCount
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