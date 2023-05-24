using BenchmarkDotNet.Attributes;

namespace MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer
{
    public class GetOrderWithDetailsByIdSqlServer : BenchmarkBase
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
            _dapperSqlServer.SelectOrderWithDetailsAndEmployeeById(id);
        }

        [Benchmark]
        public void EntityFramework()
        {
            _efSqlServer.SelectOrderWithDetailsAndEmployeeById(id);
        }

        [Benchmark]
        public void NHibernate()
        {
            _nHibernateSqlServer.SelectOrderWithDetailsAndEmployeeById(id);
        }
    }
}
