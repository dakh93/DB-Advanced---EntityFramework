using System;
using System.Data.SqlClient;
using System.Linq;

namespace P04.Add_Minions
{
    public class StartUp
    {
        public static void Main()
        {
            string[] minionInput =
                Console.ReadLine()
                    .Split(new[] {"Minion:", " "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            string minName = minionInput[0];
            int minAge = int.Parse(minionInput[1]);
            string minTown = minionInput[2];

            string villainName =
                Console.ReadLine()
                    .Split(new[] {"Villain: "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()
                    .First();

            var builder = new SqlConnectionStringBuilder()
            {
                ["Server"] = ".\\SQLEXPRESS",
                ["Integrated Security"] = "true",
                ["Database"] = "MinionsDB",
            };

            var connection = new SqlConnection(builder.ToString());

            connection.Open();
            using (connection)
            {
                var isTownExists = "SELECT * FROM Towns AS t WHERE t.[Name] = @townName";
                var townCommand = new SqlCommand(isTownExists, connection);
                townCommand.Parameters.AddWithValue("@townName", minTown);

                var townReader = townCommand.ExecuteReader();
                //CHECK FOR TOWN
                using (townReader)
                {
                    if (!townReader.Read())
                    {
                        townReader.Close();
                        var addTownToDB = "INSERT INTO Towns(Name, CountryId) VALUES(@townName, 1)";
                        var addTownCommand = new SqlCommand(addTownToDB, connection);
                        addTownCommand.Parameters.AddWithValue("@townName", minTown);
                        addTownCommand.ExecuteNonQuery();
                        Console.WriteLine($"Town {minTown} was added to the database.");
                    }
                }
                
                var isMinionExists =
                    "SELECT m.[Name], m.Age FROM Minions AS m WHERE m.[Name] = @minName AND m.Age = @minAge";
                var minionCommand = new SqlCommand(isMinionExists,connection);
                minionCommand.Parameters.AddWithValue("@minName", minName);
                minionCommand.Parameters.AddWithValue("@minAge", minAge);

                var minReader = minionCommand.ExecuteReader();
                using (minReader)
                {
                    if (!minReader.Read())
                    {
                        var addMinionToDB = "INSERT INTO"
                    }
                }
                //CHECK FOR MINION

            }


        }
    }
}
