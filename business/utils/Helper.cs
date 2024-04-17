using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Xml.Linq;
using M03UF5AC3.business.entities;

namespace M03UF5AC3.business.utils
{
    public class Helper
    {
        public static List<Consum> GetDataFromCsv(string csvPath)
        {
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Consum>().ToList();
        }
        public static void AddConsumToCsv(Consum consum, string csvPath)
        {
            using (var writer = new StreamWriter(csvPath, true))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    writer.WriteLine();
                    csv.WriteRecord(consum);
                }
            }
        }
    }
}
