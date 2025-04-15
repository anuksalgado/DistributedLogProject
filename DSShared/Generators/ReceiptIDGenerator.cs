internal static class ReceiptIDGenerator
{
  private static readonly Random _random = new Random();
  private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

  internal static string GenerateID(int length = 10)
  {
    return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
  }
}