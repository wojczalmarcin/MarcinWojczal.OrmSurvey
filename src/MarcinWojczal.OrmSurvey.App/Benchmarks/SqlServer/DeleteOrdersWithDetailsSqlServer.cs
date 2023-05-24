using BenchmarkDotNet.Attributes;
using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class DeleteOrdersWithDetailsSqlServer : BenchmarkBase
    {
        private List<Order> _recordsToDelete;
        private List<Order> _recordsToDeleteNhibernate;
        private List<Order> _recordsToDeleteEf;

        [Params(1, 5, 10, 100, 200, 400, 600, 800, 1000)]
        public int NumberOfRecords { get; set; }

        [IterationSetup]
        public void IterationSetup()
        {
            _recordsToDelete = _efSqlServer.SingleSelectRange(NumberOfRecords).ToList();
            _recordsToDeleteEf = _efSqlServer.SingleSelectRange(NumberOfRecords * 2).Skip(NumberOfRecords).ToList();
            _recordsToDeleteNhibernate = _efSqlServer.SingleSelectRangeWithProducts(NumberOfRecords * 3).Skip(NumberOfRecords * 2).ToList();
        }
        [Benchmark]
        public void Dapper()
        {
            _dapperSqlServer.DeleteOrdersWithDetails(_recordsToDelete);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.DeleteOrdersWithDetails(_recordsToDeleteEf);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.DeleteOrdersWithDetails(_recordsToDeleteNhibernate);
        }
    }
}
