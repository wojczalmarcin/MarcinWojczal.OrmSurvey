using BenchmarkDotNet.Attributes;
using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class GetAndDeleteOrdersWithDetailsSqlServer : BenchmarkBase
    {
        [Params(1, 5, 10, 100, 200, 400, 600, 800, 1000)]
        public int NumberOfRecords { get; set; }

        [Benchmark]
        public void Dapper()
        {
            _dapperSqlServer.SelectAndDeleteOrdersWithDetails(NumberOfRecords);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.SelectAndDeleteOrdersWithDetails(NumberOfRecords);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.SelectAndDeleteOrdersWithDetails(NumberOfRecords);
        }
    }
}
