using Npgsql;

namespace RpgShop.DAO
{
    public static class Database
    {
        private static readonly NpgsqlConnectionStringBuilder connBuilder =
            new NpgsqlConnectionStringBuilder
            {
                Host = "aws-1-sa-east-1.pooler.supabase.com",
                Port = 6543,
                Database = "postgres",
                Username = "app_dao.eiykzhhexocdnlzyzuiu",
                Password = "tcb01062026",
                SslMode = SslMode.Require,
                Pooling = false,
                MaxPoolSize = 20,
                ConnectionLifetime = 10,
                TrustServerCertificate = true
            };

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connBuilder.ToString());
        }
    }
}