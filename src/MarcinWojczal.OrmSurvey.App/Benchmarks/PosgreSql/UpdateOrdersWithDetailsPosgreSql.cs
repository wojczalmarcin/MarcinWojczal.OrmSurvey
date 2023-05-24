using BenchmarkDotNet.Attributes;
using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class UpdateOrdersWithDetailsPosgreSql : BenchmarkBase
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
            _dapperPostgreSql.UpdateOrdersWithDetails(_recordsToUpdate);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efPostgreSql.UpdateOrdersWithDetails(_recordsToUpdate);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernatePostgreSql.UpdateOrdersWithDetails(_recordsToUpdateNhibernate);
        }
    }
}
