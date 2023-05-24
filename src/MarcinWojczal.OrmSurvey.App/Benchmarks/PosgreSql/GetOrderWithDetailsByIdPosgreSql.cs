using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.PosgreSql
{
    public class GetOrderWithDetailsByIdPosgreSql : BenchmarkBase
    {
        private int id;

        [GlobalSetup]
        public void GlobalSetup()
        {
            id = GetOrderIdsSqlServer(1)[0];
        }

        [Benchmark]
        public void Dapper()
        {
            _dapperPostgreSql.SelectOrderWithDetailsAndEmployeeById(id);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efPostgreSql.SelectOrderWithDetailsAndEmployeeById(id);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernatePostgreSql.SelectOrderWithDetailsAndEmployeeById(id);
        }
    }
}
