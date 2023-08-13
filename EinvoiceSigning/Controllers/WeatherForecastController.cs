using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
namespace EinvoiceSigning.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenSignerController : ControllerBase
{
    TokenSigner tokenSigner = new TokenSigner();
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TokenSignerController> _logger;

    public TokenSignerController(ILogger<TokenSignerController> logger)
    {
        _logger = logger;
    }
    /*
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    */

    [HttpGet(Name = "SignTheCertificate")]
    public IActionResult SignTheCertificate(string folderPath, string pin, string certificateIssuer)
    {
       tokenSigner.Sign(folderPath, pin, certificateIssuer);
        return Ok();
    }




}

