using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class GetOrderByIdSqlServer : BenchmarkBase
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
            _dapperSqlServer.SelectOrderById(id);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.SelectOrderById(id);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.SelectOrderById(id);
        }
    }
}
