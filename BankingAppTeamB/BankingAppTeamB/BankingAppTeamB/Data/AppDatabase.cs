using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace BankingAppTeamB.Data
{
    public static class AppDatabase
    {
        public static SqlConnection GetConnection()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("BankingApp");
            return new SqlConnection(connectionString);
        }
    }
}
