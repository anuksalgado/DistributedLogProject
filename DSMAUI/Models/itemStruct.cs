public class itemStruct
{
    public string itemName { get; set; }
    public double price { get; set; }  
    public DateTime mfd { get; set; }
    public string Display => $"{itemName} - ${price}";

     public string DisplayItems => $"{itemName} | Qty: {quantity} | Price: {price:C} | MFD: {mfd:dd MMM yyyy}";
    public int quantity {get;set; }
}