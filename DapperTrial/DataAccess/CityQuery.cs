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

            string sql = "SELECT id, name, population FROM city WHERE countrycode = @countrycode;";

            string connectionString = "server=localhost;database=world;AllowUserVariables=True;password=root;user=root";

            using (var connection = new MySqlConnection(connectionString))
            {
                cities = connection.Query<City>(sql, new { countrycode = code }).ToList();
            }

            return cities;

        }
    }
}
