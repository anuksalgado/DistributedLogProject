using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    //Every public method in the application is accessible 
    // 
    // GET: /HelloWorld/
    public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }

    public string WelcomeNum(string name, int numTime = 1)
    {
      return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTime}");
    }

    public string GenerateLogs()
    {
      var LogGeneration = new LogGeneration();
      return HtmlEncoder.Default.Encode($"{LogGeneration.GenerateLogs()}");
    }

    [HttpGet("generateRando")]
    public IActionResult GenerateRando()
    {
        var logGen = new LogGeneration();
        var logs = logGen.GenerateRandomLogs();
        return Ok(logs);
    }
}