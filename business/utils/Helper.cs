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
        public static void CsvToXml(string csvPath, string xmlPath)
        {
            if (File.Exists(xmlPath))
            {
                XDocument doc = XDocument.Load(xmlPath);
                if (doc.Root == null)
                {
                    SaveDataToXml(GetDataFromCsv(csvPath), xmlPath);
                }
            }
            else
            {
                SaveDataToXml(GetDataFromCsv(csvPath), xmlPath);
            }
        }
        public static List<Consum> GetDataFromCsv(string csvPath)
        {
            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Consum>().ToList();
        }
        public static void SaveDataToXml(List<Consum> infoComarcas, string xmlPath)
        {
            const string SuccessMsg = "Dades emmagatzemades correctament";
            const string ErrorMsg = "Error: {0}";
            try
            {
                XDocument doc;

                if (File.Exists(xmlPath))
                {
                    doc = XDocument.Load(xmlPath);

                    if (doc.Root == null)
                    {
                        doc.Add(new XElement("Comarcas"));
                    }
                }
                else
                {
                    doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Comarcas"));
                }
                List<int> list = new List<int>();
                foreach (Consum infoComarca in infoComarcas)
                {
                    if (!list.Contains(infoComarca.CodiComarca))
                    {
                        XElement comarca =
                            new XElement("Comarca",
                            new XElement("CodiComarca", infoComarca.CodiComarca),
                            new XElement("NomComarca", infoComarca.Comarca));
                        doc.Root.Add(comarca);
                        list.Add(infoComarca.CodiComarca);
                    }
                }
                doc.Save(xmlPath);
                Console.WriteLine();
                Console.WriteLine(SuccessMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ErrorMsg, ex.Message);
            }
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
        public static List<string> GetComarquesXML()
        {
            XDocument doc = XDocument.Load("../../../files/Consum.xml");
            return doc.Descendants("Comarca").Select(x => x.Element("NomComarca").Value).ToList();
        }
    }
}
