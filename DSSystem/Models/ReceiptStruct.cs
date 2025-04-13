using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class ReceiptStruct
{
  [Key]
  public string ReceiptID {get;set;}
  public List<itemStruct> items { get; set; } = new List<itemStruct>(); //receipt can hold multiple items
  public DateTime puchaseDate {get;set;}
  public string cusName {get;set;}
}