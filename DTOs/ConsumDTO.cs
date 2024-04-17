using CsvHelper.Configuration.Attributes;

namespace M03UF5AC3
{
    public class ConsumDTO
    {
        public int ID { get; set; }
        public int Any { get; set; }
        public int CodiComarca { get; set; }
        public string? Comarca { get; set; }
        public int Poblacio { get; set; }
        public int DomesticXarxa { get; set; }
        public int ActivitatsEconomiques { get; set; }
        public int Total { get; set; }
        public double ConsumDomesticPerCapita { get; set; }
    }
}
