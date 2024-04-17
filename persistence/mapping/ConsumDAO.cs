using Npgsql;
using M03UF5AC3.persistence.utils;
using M03UF5AC3.persistence.DAO;


namespace M03UF5AC3.persistence.mapping
{
    public class ConsumDAO : IConsumDAO
    {
        private readonly string connString;
        public ConsumDAO(string connString)
        {
            this.connString = connString;
        }
        public ConsumDTO GetConsumByID(int id)
        {
            ConsumDTO consum = null;
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM consum WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            consum = NpgsqlUtils.GetContact(reader);
                        }
                    }
                }
            }
            return consum;
        }
        public List<ConsumDTO> GetAll()
        {
            List<ConsumDTO> consums = new List<ConsumDTO>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM consum", conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consums.Add(NpgsqlUtils.GetContact(reader));
                        }
                    }
                }
            }
            return consums;
        }
        public void Insert(ConsumDTO consum)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO consum (year, codicomarca, comarca, poblacio, domesticxarxa, activitatseconomiques, total, consumdomesticpercapita) VALUES (@Any, @CodiComarca, @Comarca, @Poblacio, @DomesticXarxa, @ActivitatsEconomiques, @Total, @ConsumDomesticPerCapita)", conn))
                {
                    cmd.Parameters.AddWithValue("Any", consum.Any);
                    cmd.Parameters.AddWithValue("CodiComarca", consum.CodiComarca);
                    cmd.Parameters.AddWithValue("Comarca", consum.Comarca);
                    cmd.Parameters.AddWithValue("Poblacio", consum.Poblacio);
                    cmd.Parameters.AddWithValue("DomesticXarxa", consum.DomesticXarxa);
                    cmd.Parameters.AddWithValue("ActivitatsEconomiques", consum.ActivitatsEconomiques);
                    cmd.Parameters.AddWithValue("Total", consum.Total);
                    cmd.Parameters.AddWithValue("ConsumDomesticPerCapita", consum.ConsumDomesticPerCapita);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(ConsumDTO consum)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE consum SET any = @Any, codicomarca = @CodiComarca, comarca = @Comarca, poblacio = @Poblacio, domesticxarxa = @DomesticXarxa, activitatseconomiques = @ActivitatsEconomiques, total = @Total, consumdomesticpercapita = @ConsumDomesticPerCapita WHERE id = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("Any", consum.Any);
                    cmd.Parameters.AddWithValue("CodiComarca", consum.CodiComarca);
                    cmd.Parameters.AddWithValue("Comarca", consum.Comarca);
                    cmd.Parameters.AddWithValue("Poblacio", consum.Poblacio);
                    cmd.Parameters.AddWithValue("DomesticXarxa", consum.DomesticXarxa);
                    cmd.Parameters.AddWithValue("ActivitatsEconomiques", consum.ActivitatsEconomiques);
                    cmd.Parameters.AddWithValue("Total", consum.Total);
                    cmd.Parameters.AddWithValue("ConsumDomesticPerCapita", consum.ConsumDomesticPerCapita);
                    cmd.Parameters.AddWithValue("ID", consum.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(ConsumDTO consum)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM consum WHERE id = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("ID", consum.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int GetIdComarca(string comarca)
        {
            int id = 0;
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT codicomarca FROM consum WHERE comarca = @Comarca", conn))
                {
                    cmd.Parameters.AddWithValue("Comarca", comarca);
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                    }
                }
            }
            return id;
        }
        public List<string> GetAllComarcas()
        {
            List<string> comarcas = new List<string>();
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT comarca FROM consum", conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comarcas.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return comarcas;
        }
        public bool IsHighestDomCons(double cons)
        {
            ConsumDAO consumDAO = new ConsumDAO(NpgsqlUtils.OpenConnection());
            List<ConsumDTO> consums = consumDAO.GetAll();
            double highestCons = consums.Max(x => x.ConsumDomesticPerCapita);
            return cons == highestCons;
        }
        public bool IsLowestDomCons(double cons)
        {
            ConsumDAO consumDAO = new ConsumDAO(NpgsqlUtils.OpenConnection());
            List<ConsumDTO> consums = consumDAO.GetAll();
            double lowestCons = consums.Min(x => x.ConsumDomesticPerCapita);
            return cons == lowestCons;
        }
    }
}
