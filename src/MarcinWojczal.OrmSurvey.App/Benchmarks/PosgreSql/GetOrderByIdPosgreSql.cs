using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.PosgreSql
{
    public class GetOrderByIdPosgreSql : BenchmarkBase
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
            _dapperPostgreSql.SelectOrderById(id);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _dapperPostgreSql.SelectOrderById(id);
        }

        [Benchmark]
        public void NHibernate()
        {
            _dapperPostgreSql.SelectOrderById(id);
        }
    }
}
