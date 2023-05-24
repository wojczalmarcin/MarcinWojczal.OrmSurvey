using System.Data.Common;

namespace MarcinWojczal.OrmSurvey.Dapper
{
    internal sealed class SurveyDbContext<T> where T : DbConnection
    {
        private readonly Func<T> _createConnection;

        internal SurveyDbContext(Func<T> createConnection)
        {
            _createConnection = createConnection;
        }

        public DbConnection CreateConnection()
            => _createConnection();
    }
}
