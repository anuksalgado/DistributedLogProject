public class ReceiptStruct
{
  public List<itemStruct> items { get; set; } = new List<itemStruct>(); //receipt can hold multiple items
  public DateTime puchaseDate {get;set;}
  public string cusName {get;set;}
}