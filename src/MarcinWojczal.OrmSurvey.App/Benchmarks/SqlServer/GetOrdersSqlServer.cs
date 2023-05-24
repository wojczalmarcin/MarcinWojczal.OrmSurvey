using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class GetOrdersSqlServer : BenchmarkBase
    {
        [Params(1, 10, 200, 600, 1000, 2500, 5000, 7500, 10000)]
        public int NumberOfRecords { get; set; }

        [Benchmark]
        public void Dapper()
        {
            _dapperSqlServer.SelectOrders(NumberOfRecords);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.SelectOrders(NumberOfRecords);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.SelectOrders(NumberOfRecords);
        }
    }
}
