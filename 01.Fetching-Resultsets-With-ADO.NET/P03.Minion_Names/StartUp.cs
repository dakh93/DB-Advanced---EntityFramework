using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace P03.Minion_Names
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var builder = new SqlConnectionStringBuilder()
            {
                ["Server"] = ".\\SQLEXPRESS",
                ["Database"] = "MinionsDB",
                ["Integrated Security"] = "True",
            };

            var connection = new SqlConnection(builder.ToString());
            int villainId = int.Parse(Console.ReadLine());

            connection.Open();
            using (connection)
            {
                StringBuilder result = new StringBuilder();
                int builderLinesCnt = 0;
                var villanName = "SELECT Name FROM Villains WHERE Id = @villainId";
                var command = new SqlCommand(villanName, connection);
                command.Parameters.AddWithValue("@villainId", villainId);

                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        result.AppendLine($"Villain: {reader[0]}");
                        builderLinesCnt++;
                    }
                }
                if (String.IsNullOrEmpty(result.ToString().TrimEnd()))
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                var villainMinions =
                    "SELECT v.[Name] AS [VillainName],  m.[Name] AS [MinionName],   m.Age AS [MinionAge] FROM Villains AS v INNER JOIN MinionsVillains AS mv ON mv.VillainId = v.Id INNER JOIN Minions AS m ON m.Id = mv.MinionId GROUP BY v.Id, v.[Name], m.[Name], m.Age HAVING v.Id = @villainId ORDER BY m.[Name] ASC";

                 command = new SqlCommand(villainMinions, connection);
                command.Parameters.AddWithValue("@villainId", villainId);


                reader = command.ExecuteReader();
                using (reader)
                {

                    var cnt = 1;
                    
                    while (reader.Read())
                    {

                        string minName = (string)reader["MinionName"];
                        int minAge = (int)reader["MinionAge"];

                        result.AppendLine($"{cnt}. {minName} {minAge}");
                        builderLinesCnt++;

                        cnt++;
                    }

                    if (builderLinesCnt < 2)
                    {
                        result.AppendLine($"(no minions)");
                    }
                    
                    Console.WriteLine(result.ToString().TrimEnd());
                }

            }
        }

       
    }
}
