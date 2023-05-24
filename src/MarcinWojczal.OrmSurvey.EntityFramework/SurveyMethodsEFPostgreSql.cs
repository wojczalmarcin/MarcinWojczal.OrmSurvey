using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging;

namespace MarcinWojczal.OrmSurvey.EntityFramework
{
    public sealed class SurveyMethodsEFPostgreSql : SurveyMethods
    {
        public SurveyMethodsEFPostgreSql(string posgreSqlConnectionString)
            : base(new DbContextOptionsBuilder<SurveyDbContext>()
                  .UseNpgsql(posgreSqlConnectionString)
                  .UseLoggerFactory(new LoggerFactory(new[] { new DebugLoggerProvider() }))
                  .Options)
        {
        }
    }
}
