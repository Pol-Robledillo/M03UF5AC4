using Microsoft.Extensions.Configuration;
using Npgsql;

namespace M03UF5AC3.persistence.utils
{
    public class NpgsqlUtils
    {
        public static string OpenConnection()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config.GetConnectionString("MyPostgresConn");
        }

        public static ConsumDTO GetContact(NpgsqlDataReader reader)
        {
            ConsumDTO c = new ConsumDTO
            {
                Any = reader.GetInt32(0),
                CodiComarca = reader.GetInt32(1),
                Comarca = reader.GetString(2),
                Poblacio = reader.GetInt32(3),
                DomesticXarxa = reader.GetInt32(4),
                ActivitatsEconomiques = reader.GetInt32(5),
                Total = reader.GetInt32(6),
                ConsumDomesticPerCapita = reader.GetDouble(7)
            };
            return c;
        }
    }
}
