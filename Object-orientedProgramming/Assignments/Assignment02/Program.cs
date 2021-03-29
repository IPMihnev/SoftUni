using Assignment02;
using Assignment02.Data;
using Assignment02.Importer;


namespace TechnicalAssignments
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();

            db.Database.EnsureCreated();

            IOfferService offerService = new OfferService(db);

            CSVImporter importer = new CSVImporter();

            importer.Import(offerService);
        }
    }

}
