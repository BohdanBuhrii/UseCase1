using RestCountriesAPI.Services;
using System.Text.Json.Nodes;

namespace RestCountriesAPITests
{
    public class CountriesExtentionsTests
    {
        private List<JsonNode?> countries;

        [SetUp]
        public void Setup()
        {
            countries = new List<JsonNode?>
            {
                JsonNode.Parse("{\"name\": { \"common\": \"United States\" }, \"population\": 329484123 }"),
                JsonNode.Parse("{\"name\": { \"common\": \"Ukraine\" }, \"population\": 44134693 }"),
                JsonNode.Parse("{\"name\": { \"common\": \"Italy\" }, \"population\": 59554023 }")
            };
        }

        [Test]
        public void FilterByName_ShouldNotFilter_IfSearchIsNull()
        {
            // Arrange
            var initLen = countries.Count;

            // Act
            var result = countries.FilterByName(null);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(initLen));
        }

        [Theory]
        [TestCase("ukr")]
        [TestCase("UKR")]
        [TestCase("rain")]
        public void FilterByName_ShouldFilterByName_IfSearchTermNotNull(string searchTerm)
        {
            // Arrange
            var expected = countries[1];

            // Act
            var result = countries.FilterByName(searchTerm);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Count(), Is.EqualTo(1));
                Assert.That(result.First(), Is.EqualTo(expected));
            });  
        }

        [Test]
        public void FilterByPopulation_ShouldNotFilter_IfMaxPopulationIsNull()
        {
            // Arrange
            var initLen = countries.Count;

            // Act
            var result = countries.FilterByPopulation(null);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(initLen));
        }

        [Theory]
        [TestCase(1, 0)]
        [TestCase(400, 3)]
        [TestCase(60, 2)]
        public void FilterByPopulation_ShouldFilterByName_IfSearchTermNotNull(int maxPopulation, int expectedCount)
        {
            // Act
            var result = countries.FilterByPopulation(maxPopulation);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }

        [Theory]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("test")]
        public void OrderByName_ShouldNotSort_IfOrderIsInvalid(string order)
        {
            // Arrange
            var expected = countries;

            // Act
            var result = countries.OrderByName(order);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase("ascend", 2)]
        [TestCase("descend", 0)]
        public void OrderByName_ShouldSort_DependingOnParameter(string order, int expectedFirstCountryIndex)
        {
          // Arrange
          var firstCountry = countries[expectedFirstCountryIndex];

          // Act
          var result = countries.OrderByName(order);

          // Assert
          Assert.That(result.First(), Is.EqualTo(firstCountry));
        }

        [Theory]
        [TestCase(null, 3)]
        [TestCase(100, 3)]
        [TestCase(3, 3)]
        [TestCase(1, 1)]
        public void TakeUpTo_ShouldReturnLimitCountries_IfLimitIsSpecified(int? limit, int expectedCount)
        {
            // Act
            var result = countries.TakeUpTo(limit);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(expectedCount));
        }
    }
}