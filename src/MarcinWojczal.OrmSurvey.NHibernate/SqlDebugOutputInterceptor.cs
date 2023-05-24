using NHibernate;
using NHibernate.SqlCommand;
using System.Diagnostics;

namespace MarcinWojczal.OrmSurvey.NHibernate
{
    internal class SqlDebugOutputInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Debug.Write("NHibernate: ");
            Debug.WriteLine(sql);

            return base.OnPrepareStatement(sql);
        }
    }
}
