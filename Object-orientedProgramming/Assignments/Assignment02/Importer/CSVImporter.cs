using CsvHelper;
using System.Globalization;
using System.IO;
using System.Text;
using TechnicalAssignments;

namespace Assignment02.Importer
{
    public class CSVImporter
    {
        public void Import(IOfferService offerService)
        {
            var text = File.ReadAllText("offers.csv");
            text = text.Replace(",", ".").Replace(";", ",");
            File.WriteAllText("replacedCSVFile.csv", text, Encoding.UTF8);

            using (var reader = new StreamReader("replacedCSVFile.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<OfferAsCSV>();
                foreach (var record in records)
                {
                    offerService.Add(record.monthlyFee, record.newContractsForMonth, record.sameContractsForMonth, record.CancelledContractsForMonth);
                }
            }
        }
    }
}
