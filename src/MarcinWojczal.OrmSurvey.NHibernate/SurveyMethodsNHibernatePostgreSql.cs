using NHibernate.Dialect;

namespace MarcinWojczal.OrmSurvey.NHibernate
{
    public class SurveyMethodsNHibernatePostgreSql : SurveyMethods
    {
        public SurveyMethodsNHibernatePostgreSql(string posgreSqlConnectionString)
            : base(db =>
            {
                db.ConnectionString = posgreSqlConnectionString;
                db.Dialect<PostgreSQLDialect>();
            })
        {
        }
    }
}
