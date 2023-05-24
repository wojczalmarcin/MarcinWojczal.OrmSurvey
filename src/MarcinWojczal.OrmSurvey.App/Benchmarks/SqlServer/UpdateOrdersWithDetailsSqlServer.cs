using BenchmarkDotNet.Attributes;
using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class UpdateOrdersWithDetailsSqlServer : BenchmarkBase
    {
        private List<Order> _recordsToUpdate;
        private List<Order> _recordsToUpdateNhibernate;

        [Params(1, 5, 10, 100, 200, 400, 600, 800, 1000)]
        public int NumberOfRecords { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _recordsToUpdate = _efSqlServer.SingleSelectRange(NumberOfRecords).ToList();
            _recordsToUpdateNhibernate = _efSqlServer.SingleSelectRangeWithProducts(NumberOfRecords).ToList();
        }

        [Benchmark]
        public void Dapper()
        {
            _dapperSqlServer.UpdateOrdersWithDetails(_recordsToUpdate);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.UpdateOrdersWithDetails(_recordsToUpdate);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.UpdateOrdersWithDetails(_recordsToUpdateNhibernate);
        }
    }
}
