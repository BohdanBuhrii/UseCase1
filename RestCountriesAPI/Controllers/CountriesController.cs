using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestCountriesAPI.Options;
using RestCountriesAPI.Services;
using System.Text.Json.Nodes;

namespace RestCountriesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly RestCountriesOptions _options;

    public CountriesController(IHttpClientFactory httpClientFactory, IOptions<RestCountriesOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    [HttpGet(Name = "GetCountries")]
    public async Task<IEnumerable<JsonNode?>> Get(string? nameSearch, int? maxPopulation, string? order, int? limit)
    {
        using var client = _httpClientFactory.CreateClient();

        var countries = JsonNode.Parse(await client.GetStringAsync(_options.Url)) ?? new JsonArray();

        return countries
            .AsArray()
            .AsEnumerable()
            .FilterByName(nameSearch)
            .FilterByPopulation(maxPopulation)
            .OrderByName(order)
            .TakeUpTo(limit);
    }
}
