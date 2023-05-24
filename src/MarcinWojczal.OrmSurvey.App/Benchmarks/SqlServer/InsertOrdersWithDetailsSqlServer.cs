using BenchmarkDotNet.Attributes;
using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class InsertOrdersWithDetailsSqlServer : BenchmarkBase
    {
        private List<Order> _recordsToInsert;
        private List<Order> _recordsToInsertNhibernate;

        [Params(1, 5, 10, 100, 200, 400, 600, 800, 1000)]
        public int NumberOfRecords { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            _recordsToInsert = _efSqlServer.SingleSelectRange(NumberOfRecords).ToList();
            _recordsToInsertNhibernate = _efSqlServer.SingleSelectRangeWithProducts(NumberOfRecords).ToList();
        }

        [IterationSetup]
        public void IterationSetup()
        {
            DefaultIds(_recordsToInsert);
            DefaultIds(_recordsToInsertNhibernate);
        }

        [Benchmark]
        public void Dapper()
        {
           
            _dapperSqlServer.InsertOrdersWithDetails(_recordsToInsert);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.InsertOrdersWithDetails(_recordsToInsert);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.InsertOrdersWithDetails(_recordsToInsertNhibernate);
        }
    }
}
