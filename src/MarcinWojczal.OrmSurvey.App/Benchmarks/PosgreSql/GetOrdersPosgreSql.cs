using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.PosgreSql
{
    public class GetOrdersPosgreSql : BenchmarkBase
    {
        [Params(1, 10, 200, 600, 1000, 2500, 5000, 7500, 10000)]
        public int NumberOfRecords { get; set; }

        [Benchmark]
        public void Dapper()
        {
            _dapperPostgreSql.SelectOrders(NumberOfRecords);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efPostgreSql.SelectOrders(NumberOfRecords);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernatePostgreSql.SelectOrders(NumberOfRecords);
        }
    }
}
