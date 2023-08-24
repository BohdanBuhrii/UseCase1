using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace RestCountriesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public CountriesController(ILogger<CountriesController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet(Name = "GetCountries")]
    public async Task<dynamic[]> Get()
    {
        using var client = _httpClientFactory.CreateClient();

        var countries = await client.GetFromJsonAsync<dynamic[]>("https://restcountries.com/v3.1/all");

        return countries;
    }
}
