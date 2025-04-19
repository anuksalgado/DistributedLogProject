using System.ComponentModel.DataAnnotations;

public class ReceiptStruct
{
  [Key]
  public required string ReceiptID {get;set;}
  public List<itemStruct> items { get; set; } = new List<itemStruct>(); //receipt can hold multiple items
  public DateTime puchaseDate {get;set;}
  public required string cusName {get;set;}
}