using BenchmarkDotNet.Attributes;
using MarcinWojczal.OrmSurvey.Dapper;
using MarcinWojczal.OrmSurvey.EntityFramework;
using MarcinWojczal.OrmSurvey.Models;
using MarcinWojczal.OrmSurvey.NHibernate;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    //[MinIterationCount(20)]
    //[MaxIterationCount(40)]
    //[BenchmarkDotNet.Attributes.]
    public class BenchmarkBase
    {
        protected SurveyMethodsEFSqlServer _efSqlServer;
        protected SurveyMethodsNHibernateSqlServer _nHibernateSqlServer;
        protected SurveyMethodsDapperSqlServer _dapperSqlServer;
        protected SurveyMethodsEFPostgreSql _efPostgreSql;
        protected SurveyMethodsNHibernatePostgreSql _nHibernatePostgreSql;
        protected SurveyMethodsDapperPostgreSql _dapperPostgreSql;
        private static string _sqlServerConnectionString;
        private static string _posgreSqlConnectionString;

        public BenchmarkBase()
        {
            var builder = new ConfigurationBuilder()
                //.SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString())
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Config.json", optional: false);
            var config = builder.Build();

            _sqlServerConnectionString = config.GetSection("DataBase:SqlServerConnectionString").Value;
            _posgreSqlConnectionString = config.GetSection("DataBase:PostgreSqlConnectionString").Value;

            _efSqlServer = new SurveyMethodsEFSqlServer(_sqlServerConnectionString);
            _nHibernateSqlServer = new SurveyMethodsNHibernateSqlServer(_sqlServerConnectionString);
            _nHibernateSqlServer.BuildSession();
            _dapperSqlServer = new SurveyMethodsDapperSqlServer(_sqlServerConnectionString);
            _efPostgreSql = new SurveyMethodsEFPostgreSql(_posgreSqlConnectionString);
            _nHibernatePostgreSql = new SurveyMethodsNHibernatePostgreSql(_posgreSqlConnectionString);
            _dapperPostgreSql = new SurveyMethodsDapperPostgreSql(_posgreSqlConnectionString);
        }

        protected static IReadOnlyList<int> GetOrderIdsSqlServer(int numberOfRecords)
            => GetOrderIds(numberOfRecords, _sqlServerConnectionString);

        protected static IReadOnlyList<int> GetOrderIdsPostgreSql(int numberOfRecords)
            => GetOrderIds(numberOfRecords, _posgreSqlConnectionString);

        protected void DefaultIds(List<Order> list)
        {
            foreach (var record in list)
            {
                record.Id = default;
                foreach (var orderDetail in record.OrderDetails)
                {
                    orderDetail.OrderID = default;
                }
            }
        }

        private static IReadOnlyList<int> GetOrderIds(int numberOfRecords, string connectionString)
        {
            var result = new List<int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "SELECT TOP(@numberOfRecords) OrderID FROM dbo.Orders WITH (NOLOCK) ORDER BY OrderID DESC; ";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("numberOfRecords", numberOfRecords);
                connection.Open();
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var item = reader.GetInt32(reader.GetOrdinal("OrderID"));
                        result.Add(item);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return result;
        }
    }
}
