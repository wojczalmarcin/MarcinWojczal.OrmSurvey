using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.PosgreSql
{
    public class GetAndDeleteOrdersWithDetailsPosgreSql : BenchmarkBase
    {
        [Params(1, 5, 10, 100, 200, 400, 600, 800, 1000)]
        public int NumberOfRecords { get; set; }

        [Benchmark]
        public void Dapper()
        {
            _dapperPostgreSql.SelectAndDeleteOrdersWithDetails(NumberOfRecords);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efPostgreSql.SelectAndDeleteOrdersWithDetails(NumberOfRecords);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernatePostgreSql.SelectAndDeleteOrdersWithDetails(NumberOfRecords);
        }
    }
}
