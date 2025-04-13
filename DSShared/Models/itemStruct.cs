using System.ComponentModel.DataAnnotations;

public class itemStruct
{
    [Key]
    public int Id { get; set; }
    public string itemName { get; set; } = default!;
    public int price { get; set; }
    public DateTime MFD { get; set; }
    public int quantity { get; set; }

    public string ReceiptStructReceiptID { get; set; } = default!; //FK
    public ReceiptStruct? ReceiptStruct { get; set; }
}
