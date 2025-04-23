using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace DSMAUI;

public partial class Receipt : ContentPage
{
    public ObservableCollection<itemStruct> items { get; set; } = new();

    public string CusName { get; set; }

    public Receipt(string cusName, ReceiptStruct receipt)
    {
        InitializeComponent();
        CusName = cusName;
        items = new ObservableCollection<itemStruct>(receipt.items);
        BindingContext = this;
    }
    async void ReturnNav(object sender, EventArgs args)
    {
			
      await Navigation.PopAsync();
    }
}
