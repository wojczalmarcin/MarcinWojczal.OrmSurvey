using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging;

namespace MarcinWojczal.OrmSurvey.EntityFramework
{
    public sealed class SurveyMethodsEFSqlServer : SurveyMethods
    {
        public SurveyMethodsEFSqlServer(string sqlServerConnectionString) 
            : base(new DbContextOptionsBuilder<SurveyDbContext>()
                  .UseSqlServer(sqlServerConnectionString)
                  .UseLoggerFactory(new LoggerFactory(new[] {new DebugLoggerProvider()}))
                  .Options)
        {
        }
    }
}