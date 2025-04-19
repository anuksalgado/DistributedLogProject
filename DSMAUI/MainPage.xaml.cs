using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DSMAUI;


public partial class MainPage : ContentPage
{
	 public ObservableCollection<itemStruct> items { get; } = new(); //gets set in XAML for display

	public async Task loadItems()
	{
		
		var service = new ItemService();
		var result = await service.GetItemsAsync();
		
		foreach(var item in result)
		{
			items.Add(item);
			//System.Diagnostics.Debug.WriteLine($"Tester item {item.itemName}");
		}
	}
	public MainPage()
	{
		//Trace.WriteLine($"Got items");
		InitializeComponent();
		BindingContext = this;
		_ = loadItems();
	}
	
}