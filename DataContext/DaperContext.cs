using Npgsql;

namespace PracticeAPI.DataContext;

public class DaperContext
{
    private readonly string _connectionString="Server=localhost; port=5432; Database=TestDB; USER ID=postgres; PASSWORD=1234";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}