using MarcinWojczal.OrmSurvey.Core;
using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.EntityFramework
{
    public abstract class SurveyMethods : SurveyMethodsBase, IDataAccessMethods
    {
        internal readonly PooledDbContextFactory<SurveyDbContext> _factory;

        internal SurveyMethods(DbContextOptions<SurveyDbContext> options)
        {
            _factory = new PooledDbContextFactory<SurveyDbContext>(options);
        }

        public void SelectOrderById(int orderId)
        {
            using var context = _factory.CreateDbContext();

            var result = context.Orders
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == orderId);
        }

        public void SelectOrderWithDetailsAndEmployeeById(int orderId)
        {
            using var context = _factory.CreateDbContext();

            var result = GetOrdersWithDetailsAndEmployee(context)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == orderId);
        }

        public IReadOnlyList<Order> SingleSelectRange(int numberOfRecords)
        {
            using var context = _factory.CreateDbContext();

            return context.Orders
                .AsNoTracking()
                    .Include(x => x.OrderDetails)
                .Skip(2000)
                .Take(numberOfRecords)
                .ToList();
        }

        public IReadOnlyList<Order> SingleSelectRangeWithProducts(int numberOfRecords)
        {
            using var context = _factory.CreateDbContext();

            return context.Orders
                .AsNoTracking()
                .Include(x => x.OrderDetails)
                    .ThenInclude(x => x.Product)
                .Skip(2000)
                .Take(numberOfRecords)
                .ToList();

        }
        public void SelectOrders(int numberOfOrders)
        {
            using var context = _factory.CreateDbContext();
            var result = context.Orders
                .AsNoTracking()
                .Where(x => x.OrderDate > DateTime.Parse("1998-01-01"))
                .Take(numberOfOrders)
                .ToList();
        }

        public void SelectOrdersWithDetailsAndEmployee(int numberOfOrders)
        {
            using var context = _factory.CreateDbContext();
            var result = GetOrdersWithDetailsAndEmployee(context)
                .AsNoTracking()
                .Where(x => x.OrderDate > DateTime.Parse("1998-01-01"))
                .Take(numberOfOrders)
                .ToList();
        }

        public void InsertOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var context = _factory.CreateDbContext();

            if (orders.Count() == 1)
                context.Orders.Add(orders.First());
            else
                context.Orders.AddRange(orders);

            context.SaveChanges();
        }

        public void SelectAndUpdateOrdersWithDetails(int numberOfRecords)
        {
            using var context = _factory.CreateDbContext();
            var orders = GetOrdersWithDetailsAndEmployee(context)
                .OrderByDescending(x => x.Id)
                .Take(numberOfRecords);

            ModifyOrders(orders);
            context.SaveChanges();
        }

        public void UpdateOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var context = _factory.CreateDbContext();
            if(orders.Count() == 1)
                context.Update(orders.First());
            else
                context.UpdateRange(orders);
            context.SaveChanges();
        }

        public void SelectAndDeleteOrdersWithDetails(int numberOfRecords)
        {
            using var context = _factory.CreateDbContext();
            var orders = GetOrdersWithDetailsAndEmployee(context)
                .OrderByDescending(x => x.Id)
                .Take(numberOfRecords);

            if (orders.Count() == 1)
                context.Orders.Remove(orders.First());
            else
                context.Orders.RemoveRange(orders);
        }
        public void DeleteOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var context = _factory.CreateDbContext();
            if (orders.Count() == 1)
            {
                var order = orders.First();
                foreach (var details in order.OrderDetails)
                {
                    context.Entry(details).State = EntityState.Deleted;
                }
                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }
            else
            {
                foreach (var order in orders)
                {
                    foreach (var details in order.OrderDetails)
                    {
                        context.Entry(details).State = EntityState.Deleted;
                    }
                    context.Entry(order).State = EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }

        private static IQueryable<Order> GetOrdersWithDetailsAndEmployee(SurveyDbContext context)
            => context.Orders
                    .Include(x => x.OrderDetails)
                    .Include(x => x.Employee.ReportsToEmployee.Territories);
    }
}
