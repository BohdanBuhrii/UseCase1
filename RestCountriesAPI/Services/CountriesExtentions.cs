using System.Text.Json;
using System.Text.Json.Nodes;

namespace RestCountriesAPI.Services
{
    public static class CountriesExtentions
    {
        public static IEnumerable<JsonNode?> FilterByName(this IEnumerable<JsonNode?> countries, string nameSearch)
            => countries.Where(x =>
            {
                if (x == null) return false;

                var name = x["name"];
                if (name is null) return false;

                var common = name["common"];
                if (common is null) return false;

                return common.ToString().ToLower().Contains(nameSearch.ToLower());
            });
    }
}
