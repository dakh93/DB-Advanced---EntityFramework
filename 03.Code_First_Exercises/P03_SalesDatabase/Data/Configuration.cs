

namespace P03_SalesDatabase.Data
{
    public class Configuration
    {
        public static string ConnectionString { get; set; } =
            "Server=.\\SQLEXPRESS;Database=Sales;Integrated Security=True";
    }
}
