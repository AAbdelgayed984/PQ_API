using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.SqlClient;

namespace PQ_API.HealthChecks
{
    public static class DBHealthCheckProvider
    {
        public static HealthCheckResult Check(string connectionString)
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException)
                {
                    return HealthCheckResult.Unhealthy();
                }
            }
            
            return HealthCheckResult.Healthy("DB is Healthy!");
        }
    }
}
