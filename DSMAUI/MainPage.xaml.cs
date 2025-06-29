using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Controls.Shapes;
using GradientStop = Microsoft.Maui.Controls.GradientStop;
using Xamarin.Google.ErrorProne.Annotations;
using System.Text.Json;
using System.Net;
using System.Threading.Tasks;


namespace DSMAUI;


public partial class MainPage : ContentPage
{
		 public ObservableCollection<itemStruct> items { get; } = new(); //gets set in XAML for display
		//StackLayout stackLayout = new StackLayout();

		IEnumerable<itemStruct> historicSelection = Enumerable.Empty<itemStruct>();
		ReceiptStruct receipt;

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
			stackLayout.Clear();
			var selectedItems = e.CurrentSelection.Cast<itemStruct>().ToList();
			//Debug.WriteLine("Selected Items:");
			historicSelection = selectedItems;
			var label =new Label{
						Text = 
						""
				};
			var border = new Border {};
			foreach (var item in selectedItems) //iterating current selected items
			{
				
					label = new Label{
						Text = item.itemName,
						TextColor = Colors.Black,
						FontSize = 16
					};

					var quantityLabel = new Label
        {
            Text = $"Qty: {item.quantity}",
            TextColor = Colors.DarkSlateGray,
            FontSize = 14,
            VerticalOptions = LayoutOptions.Center
        };

        var stepper = new Stepper
        {
            Minimum = 1,
            Maximum = 100,
            Increment = 1,
            Value = item.quantity > 0 ? item.quantity : 1,
            WidthRequest = 100
        };

        stepper.ValueChanged += (s, args) =>
        {
            item.quantity = (int)args.NewValue;
            quantityLabel.Text = $"Qty: {item.quantity}";
        };

        var horizontalLayout = new HorizontalStackLayout
        {
            Spacing = 10,
            Padding = new Thickness(5),
            Children = { label, quantityLabel, stepper }
        };
					
					//adding each item to a boarder
					 border = new Border
					{
							Content = horizontalLayout,
							Stroke = Colors.Red, 
							StrokeShape = new RoundRectangle
							{
									CornerRadius = new CornerRadius(40,40, 40, 40)
							},
							Padding = 10, 
							BackgroundColor = Colors.Transparent, 
							StrokeThickness = 2 
					};
					//Debug.WriteLine($"items{item.itemName} - {item.price:C}");
					stackLayout.Children.Add(border);
			}
			
	}
	async void purchaseButtonClick(object sender, EventArgs args)
    {
			if (!historicSelection.Any())
			{
					await DisplayAlert("Purchase", "Please select at least one item.", "OK");
					return;
			}
			var selectedItems = historicSelection.Cast<itemStruct>().ToList();
			var service = new purchaseService();
			receipt = await service.PostReceipt(selectedItems);

			if(receipt != null)
			{
				//Debug.WriteLine($"Receipt Gen ");
				//await ProduceReceiptToKafka(receipt);
				await DisplayAlert("Purchase", "Receipt generated", "OK");
				await Navigation.PushAsync(new Receipt(receipt.cusName, receipt));
			}
			else
			{
				await DisplayAlert("Purchase", "No Purchase Receipt", "OK");
			}
        
    }

		// async void TestNav(object sender, EventArgs args)
    // {
		// 		string cusName = "Test Customer";
    //     await Navigation.PushAsync(new Receipt(cusName, receipt));
    // }
}

