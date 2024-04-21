using Microsoft.Extensions.Configuration;
using Npgsql;
using M03UF5AC3.DTOs;

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
                ID = reader.GetInt32(0),
                Any = reader.GetInt32(1),
                CodiComarca = reader.GetInt32(2),
                Comarca = reader.GetString(3),
                Poblacio = reader.GetInt32(4),
                DomesticXarxa = reader.GetInt32(5),
                ActivitatsEconomiques = reader.GetInt32(6),
                Total = reader.GetInt32(7),
                ConsumDomesticPerCapita = reader.GetDouble(8)
            };
            return c;
        }
    }
}
