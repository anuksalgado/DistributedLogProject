public class itemStruct
{
    public string itemName { get; set; }
    public double price { get; set; }  
    public string Display => $"{itemName} - {price:C}";
}