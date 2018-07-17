using System;
using System.Data.SqlClient;

namespace P02.Villain_Names
{
    class StartUp   
    {
        static void Main(string[] args)
        {
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
                var villainNames =
                    "SELECT v.Name, COUNT(mv.VillainId) AS MinionCnt\r\nFROM Villains AS v\r\nINNER JOIN MinionsVillains AS mv ON mv.VillainId = v.Id\r\nGROUP BY mv.VillainId, v.Name\r\nHAVING COUNT(mv.VillainId) > 3\r\nORDER BY MinionCnt DESC";

                var command = new SqlCommand(villainNames, connection);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string villainName = (string) reader["Name"];
                        int minionsCnt = (int) reader["MinionCnt"];

                        Console.WriteLine($"{villainName} - {minionsCnt}");
                    }
                }


            }
        }
    }
}
