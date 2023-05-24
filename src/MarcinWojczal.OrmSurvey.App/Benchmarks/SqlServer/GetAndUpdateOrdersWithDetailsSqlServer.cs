using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class GetAndUpdateOrdersWithDetailsSqlServer : BenchmarkBase
    {
        [Params(1, 5, 10, 100, 200, 400, 600, 800, 1000)]
        public int NumberOfRecords { get; set; }

        [Benchmark]
        public void Dapper()
        {
            _dapperSqlServer.SelectAndUpdateOrdersWithDetails(NumberOfRecords);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.SelectAndUpdateOrdersWithDetails(NumberOfRecords);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.SelectAndUpdateOrdersWithDetails(NumberOfRecords);
        }
    }
}
