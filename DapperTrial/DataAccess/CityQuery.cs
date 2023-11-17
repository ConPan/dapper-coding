using Dapper;
using DapperTrial.Models;
using MySqlConnector;

namespace DapperTrial.DataAccess
{
    public class CityQuery
    {
        public CityQuery() { }

        public List<City> GetCities(string code)
        {
            List<City> cities = new List<City>();

            string sql = "SELECT id, name, population FROM city WHERE POPULATION BETWEEN 10000 AND 20000 ORDER BY POPULATION DESC;";

            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=16nov1971;user=root";

            using (var connection = new MySqlConnection(connectionString))
            {
                cities = connection.Query<City>(sql, new { countrycode = code }).ToList();
            }

            return cities;

        }
    }
}
