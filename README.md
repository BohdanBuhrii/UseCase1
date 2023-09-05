# UseCase1
## 1. Application Description
The application collects data from an external API, efficiently processes it into usable format for further representation. The "Rest Countries" API is used to retrieve extended information about all the countries, including country's name, population, etc.

The application provides an interface to filter contries by common name and population. Then data can be sorted or limited in amount of countries obtained. Use the following parameters to access the functionality:
* Filters values by country's 'name/common'. The filter searches for countries names that contains a string. The filter is case insensitive.
* Filters values by country's 'population'. Accepts maximum population in millions as a parameter.
* Sorts countries by 'name/common' attribute. Order parameter value can be 'ascend' or 'descend'.
* Returns up to 'limit' first countries from the array.

## 2. Running the Application Locally

1. Install .NET 6.0 SDK.
2. Clone the repository to your machine.
3. Run the app with Visual Studio or using .NET CLI:
   ```bash
   dotnet run
   ```
## 3. Endpoint usage examples

Use GET requests in order to:
1. Get all the countries:
   ```
   http://localhost:5036/countries
   ```
2. Get countries where country name contains "king":
   ```
   http://localhost:5036/Countries?nameSearch=king
   ```
3. Get countries with population less than 10 million people:
   ```
   http://localhost:5036/Countries?maxPopulation=10
   ```
4. Get all the countries ordered **ascending** by country's common name:
   ```
   http://localhost:5036/Countries?order=ascend
   ```
5. Get all the countries ordered **descending** by country's common name:
   ```
   http://localhost:5036/Countries?order=descend
   ```
6. Get 10 countries:
   ```
   http://localhost:5036/Countries?limit=10
   ```
7. Get 10 first countries ordered descending by name with 'st' part in it:
   ```
   http://localhost:5036/Countries?nameSearch=st&order=descend&limit=10
   ```
8. Get all the countries ordered ascending by country's common name where the population is less than 10 millions:
   ```
   http://localhost:5036/Countries?maxPopulation=10&order=ascend
   ```
9. Get up to 20 countries with 'a' in the name:
   ```
   http://localhost:5036/Countries?nameSearch=a&limit=20
   ```
10. Get 10 first countries ordered by name with population less than 100 millions that contain 'an' in the name: 
   ```
   http://localhost:5036/Countries?nameSearch=an&maxPopulation=100&order=ascend&limit=10
   ```