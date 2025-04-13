using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DSShared.Generators;
using DSAvalonia.Helpers; 
using DSShared.Models; 
using System.Collections.Generic;

namespace DSAvalonia.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _receiptOutput;

        public string Greeting => "Welcome to DS System";
        public string ReceiptOutput
        {
            get => _receiptOutput;
            set
            {
                _receiptOutput = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateCommand { get; }

        public MainWindowViewModel()
        {
            GenerateCommand = new RelayCommand(GenerateReceipts);
        }

        private void GenerateReceipts()
        {
            var generator = new ReceiptGenerator();
            List<ReceiptStruct> receipts;
            List<itemStruct> items;
            (receipts, items) = generator.receiptGeneratorClass(3, 5);

            var output = new System.Text.StringBuilder();
            output.AppendLine("Receipts:");
            foreach (var r in receipts)
            {
                //format Receipt details
                output.AppendLine($"- Receipt ID: {r.ReceiptID}, Customer: {r.cusName}, Purchase Date: {r.puchaseDate}");

                //loop through each item in the receips items and format each item
                // Debugging: Check if items list is null or empty
                if (r.items == null || r.items.Count == 0)
                {
                    output.AppendLine("  No items in this receipt.");
                }
                else
                {
                    // Loop through each item in the receipt's items and format each item
                    output.AppendLine("  Items:");
                    foreach (var item in r.items)
                    {
                        output.AppendLine($"    - Item: {item.itemName}, Price: {item.price:C}, Manufacture Date: {item.MFD}, Quantity: {item.quantity}");
                    }
                }
            }

            output.AppendLine("\nItems:");
            foreach (var i in items)
            {
                output.AppendLine($"- Item Name: {i.itemName}, Price: {i.price}");
            }
            ReceiptOutput = output.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
