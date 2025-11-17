using Microsoft.Data.SqlClient;

namespace VeterinariaGenesisAPI.Data;

public class ConexionDB
{
    private readonly string _connectionString;

    public ConexionDB(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("VeterinariaGenesisDB") 
            ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'VeterinariaGenesisDB' not found in appsettings.json");
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}

