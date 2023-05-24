using NHibernate.Dialect;

namespace MarcinWojczal.OrmSurvey.NHibernate
{
    public class SurveyMethodsNHibernateSqlServer : SurveyMethods
    {
        public SurveyMethodsNHibernateSqlServer(string sqlServerConnectionString)
            : base(db =>
            {
                db.ConnectionString = sqlServerConnectionString;
                db.Dialect<MsSql2012Dialect>();
                //db.LogFormattedSql = true;
                //db.LogSqlInConsole = true;
            })
        {
        }
    }
}
