using MarcinWojczal.OrmSurvey.NHibernate.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;

namespace MarcinWojczal.OrmSurvey.NHibernate
{
    internal class SesionFactory
    {
        private Configuration _configuration;

        private ISessionBuilder _sessionBuilder;

        public SesionFactory(Action<DbIntegrationConfigurationProperties> properties)
        {
            _configuration = new Configuration();
            _configuration.DataBaseIntegration(properties);
            var mapper = new ModelMapper();
            mapper.AddMapping<CategoryMapping>();
            mapper.AddMapping<CustomerMapping>();
            mapper.AddMapping<CustomersDemographicsMapping>();
            mapper.AddMapping<DemographyMapping>();
            mapper.AddMapping<EmployeeMapping>();
            mapper.AddMapping<EmployeeTerritoryMapping>();
            mapper.AddMapping<OrderDetailMapping>();
            mapper.AddMapping<OrderMapping>();
            mapper.AddMapping<ProductMapping>();
            mapper.AddMapping<RegionMapping>();
            mapper.AddMapping<ShipperMapping>();
            mapper.AddMapping<SupplierMapping>();
            mapper.AddMapping<TerritoryMapping>();
            _configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
            //_configuration.SetProperty("hibernate.default_fetch_mode", "select");
        }

        public void BuildSession()
        {
            _sessionBuilder = _configuration.BuildSessionFactory().WithOptions().Interceptor(new SqlDebugOutputInterceptor());
        }

        public ISession OpenSession()
            => _sessionBuilder.OpenSession();
    }
}
