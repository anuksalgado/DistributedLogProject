using System.ComponentModel.DataAnnotations;

public class LoginStruct
{
  [Key]
  public required String Username {get; set;}
  public required String Password {get;set;}
  public required DateTime DateTime {get;set;}
  public required bool Success {get;set;}
}