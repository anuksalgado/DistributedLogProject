using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DSSystem.Models;
using DSSystem.Services;

namespace DSSystem.Controllers;

public class testReceiptController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public testReceiptController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("testItemGen/{itemGenCount}")]
    public IActionResult itemGen(int itemGenCount)
    {
      var ReceiptGenerator = new ReceiptGenerator();
      var itemGen = ReceiptGenerator.itemGeneratorClass(itemGenCount);
      return Ok(itemGen);
    }

    [HttpGet("testReceiptGen")]
    public IActionResult receiptGen([FromQuery] int receiptGenCount, [FromQuery] int itemGenCount)
    {
      var ReceiptGenerator = new ReceiptGenerator();
      var itemGen = ReceiptGenerator.receiptGeneratorClass(receiptGenCount,itemGenCount);
      return Ok(itemGen);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
