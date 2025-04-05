class LogGeneration
{
  private string message = "Hello!";
  private int stopCase = 5;


  public String GenerateLogs()
  {

    for(int i=0; i< stopCase; i++)
    {
      message = message + i;
    }

    return message;
  }

  public List<LogMessage> GenerateRandomLogs()
  {
    var logs = new List<LogMessage>();
    for (int i = 0; i < 5; i++)
        {
            logs.Add(new LogMessage{
                Message = $"Event #{i}",
                TimeStamp = DateTime.UtcNow
            });
        }
        return logs;
  }
}