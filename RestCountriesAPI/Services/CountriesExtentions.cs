using System.Text.Json.Nodes;

namespace RestCountriesAPI.Services
{
    public static class CountriesExtentions
    {
        /// <summary>
        /// Filters values by country's 'name/common'. 
        /// The filter searches for countries names that contains a string.
        /// The filter is case insensitive.
        /// </summary>
        /// <param name="countries">Array of country nodes.</param>
        /// <param name="nameSearch">Search term.</param>
        /// <returns>Filtered array of country nodes.</returns>
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

        /// <summary>
        /// Filters values by country's 'population'. 
        /// </summary>
        /// <param name="countries">Array of country nodes.</param>
        /// <param name="maxPopulation">Maximum population in millions.</param>
        /// <returns>Countries with population less than provided number.</returns>
        public static IEnumerable<JsonNode?> FilterByPopulation(this IEnumerable<JsonNode?> countries, int maxPopulation)
            => countries.Where(x =>
            {
                if (x == null) return false;

                var population = x["population"];
                if (population is null) return false;

                return population.GetValue<int>() < maxPopulation * 10e6;
            });

    }
}
