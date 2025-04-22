using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;

namespace DSMAUI;


public partial class MainPage : ContentPage
{
	 public ObservableCollection<itemStruct> items { get; } = new(); //gets set in XAML for display
		//StackLayout stackLayout = new StackLayout();

	 public MainPage()
	{
		//Trace.WriteLine($"Got items");
		InitializeComponent();
		BindingContext = this;
		_ = loadItems();
	}

	public async Task loadItems()
	{
		
		var service = new ItemService();
		var result = await service.GetItemsAsync();
		
		foreach(var item in result)
		{
			items.Add(item);
			//System.Diagnostics.Debug.WriteLine($"Tester item {item.itemName}");
		}
		Debug.WriteLine($"Loaded {items.Count} items");
	}
	

	private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
			var selectedItems = e.CurrentSelection.Cast<itemStruct>().ToList();
			Debug.WriteLine("Selected Items:");
			var label =new Label{
						Text = 
						""
				};
			var border = new Border {};
			foreach (var item in selectedItems)
			{
					label = new Label{
						Text = item.itemName,
						TextColor = Colors.Black,
						FontSize = 16
					};
					
					//adding each item to a boarder
					 border = new Border
					{
							Content = label,
							Stroke = Colors.Red, 
							StrokeShape = new RoundRectangle
							{
									CornerRadius = new CornerRadius(40,40, 40, 40)
							},
							Padding = 10, 
							BackgroundColor = Colors.Transparent, 
							StrokeThickness = 2 
					};
					Debug.WriteLine($"items{item.itemName} - {item.price:C}");
			}

			stackLayout.Children.Add(border);
			
			
	}
	
}