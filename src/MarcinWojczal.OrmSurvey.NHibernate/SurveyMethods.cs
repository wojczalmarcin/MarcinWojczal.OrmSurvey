using MarcinWojczal.OrmSurvey.Core;
using NHibernate;
using NHibernate.Cfg.Loquacious;
using NHibernate.Linq;

namespace MarcinWojczal.OrmSurvey.NHibernate
{
    public class SurveyMethods : SurveyMethodsBase, IDataAccessMethods
    {
        internal SesionFactory _session;

        internal SurveyMethods(Action<DbIntegrationConfigurationProperties> properties)
        {
            _session = new SesionFactory(properties);
        }

        public void BuildSession()
        {
            _session.BuildSession();
        }

        public void SelectOrderById(int orderId)
        {
            using var session = _session.OpenSession();
            var result = session.Query<Order>()
                .Where(x => x.Id == orderId)
                .FirstOrDefault();
        }

        public void SelectOrderWithDetailsAndEmployeeById(int orderId)
        {
            using var session = _session.OpenSession();
            var result = GetOrdersWithDetailsAndEmployee(session)
                .Where(x => x.Id == orderId)
                .FirstOrDefault();
        }

        public void SelectOrders(int numberOfOrders)
        {
            using var session = _session.OpenSession();
            var result = session.Query<Order>()
                .Where(x => x.OrderDate > DateTime.Parse("1998-01-01"))
                .Take(numberOfOrders)
                .ToList();
        }

        public void SelectOrdersWithDetailsAndEmployee(int numberOfOrders)
        {
            using var session = _session.OpenSession();
            var result = GetOrdersWithDetailsAndEmployeeWhereOrderDate(session, numberOfOrders);

        }

        public void InsertOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var session = _session.OpenSession();
            using var transaction = session.BeginTransaction();

            if (orders.Count() == 1)
            {
                session.Save(orders.First());
                transaction.Commit();
            }
            else
            {
                
                foreach (var order in orders)
                {
                    session.Save(order);
                }
                transaction.Commit();
            }
        }

        public void SelectAndUpdateOrdersWithDetails(int numberOfRecords)
        {
            using var session = _session.OpenSession();
            var orders = GetOrdersWithDetailsAndEmployee(session, numberOfRecords);

            ModifyOrders(orders);
            session.Flush();
        }

        public void UpdateOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var session = _session.OpenSession();
            foreach (var order in orders)
            {
                session.Update(order);
            }
        }

        public void SelectAndDeleteOrdersWithDetails(int numberOfRecords)
        {
            using var session = _session.OpenSession();
            var orders = GetOrdersWithDetailsAndEmployee(session, numberOfRecords);

            if (orders.Count() == 1)
            {
                var order = orders.First();
                order.OrderDetails.Clear();
                session.Delete(order);
            }
            else
            {
                using var transaction = session.BeginTransaction();
                foreach (var order in orders)
                {
                    order.OrderDetails.Clear();
                    session.Delete(order);
                }
                transaction.Commit();
            }  
        }

        public void DeleteOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var session = _session.OpenSession();
            using var transaction = session.BeginTransaction();
            if (orders.Count() == 1)
            {
                var order = orders.First();
                foreach(var details in order.OrderDetails)
                {
                    session.Delete(details);
                }
                session.Delete(order);
                transaction.Commit();
            }
            else
            {
                foreach (var order in orders)
                {
                    foreach (var details in order.OrderDetails)
                    {
                        session.Delete(details);
                    }
                    session.Delete(order);
                }
                transaction.Commit();
            }
        }

        private static INhFetchRequest<Order, Territory> GetOrdersWithDetailsAndEmployee(ISession session)
        {
            return session.Query<Order>()
                    .Fetch(o => o.OrderDetails)
                    .Fetch(o => o.Employee)
                        .ThenFetch(e => e.ReportsToEmployee)
                            .ThenFetchMany(e => e.Territories);
        }
        private static IReadOnlyList<Order> GetOrdersWithDetailsAndEmployee(ISession session, int numberOfRecords)
        {
            var topOrders = session.Query<Order>()
                .OrderByDescending(x => x.Id)
                .Take(numberOfRecords);

            return GetOrdersWithDetailsAndEmployee(session)
                    .Where(o => topOrders.Contains(o))
                    .ToList();
        }

        private static IReadOnlyList<Order> GetOrdersWithDetailsAndEmployeeWhereOrderDate(ISession session, int numberOfRecords)
        {
            var topOrders = session.Query<Order>()
                .OrderByDescending(x => x.Id)
                .Where(x => x.OrderDate > DateTime.Parse("1998-01-01"))
                .Take(numberOfRecords);

            return GetOrdersWithDetailsAndEmployee(session)
                    .Where(o => topOrders.Contains(o))
                    .ToList();
        }
    }
}
