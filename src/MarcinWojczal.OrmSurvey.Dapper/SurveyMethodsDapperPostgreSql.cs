using Npgsql;

namespace MarcinWojczal.OrmSurvey.Dapper
{
    public class SurveyMethodsDapperPostgreSql : SurveyMethods<NpgsqlConnection>
    {
        public SurveyMethodsDapperPostgreSql(string posgreSqlConnectionString) 
            : base(() => new NpgsqlConnection(posgreSqlConnectionString))
        {
        }
    }
}
