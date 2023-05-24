using System.Data.SqlClient;

namespace MarcinWojczal.OrmSurvey.Dapper
{
    public class SurveyMethodsDapperSqlServer : SurveyMethods<SqlConnection>
    {
        public SurveyMethodsDapperSqlServer(string sqlServerConnectionString)
            : base(() => new SqlConnection(sqlServerConnectionString))
        {
        }
    }
}
