
namespace P01_HospitalDatabaseStartUp
{
    using System;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Initializer;
    using P01_HospitalDatabase.Data.Models;

    public class StartUp
    {

        public static void Main(string[] args)
        {
            using (var db = new HospitalContext())
            {
                DatabaseInitializer.SeedPatients(db,100);
            }
        }
    }
}
