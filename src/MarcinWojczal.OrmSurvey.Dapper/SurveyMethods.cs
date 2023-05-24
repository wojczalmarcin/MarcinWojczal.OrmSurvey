using Dapper;
using MarcinWojczal.OrmSurvey.Core;
using MarcinWojczal.OrmSurvey.Models;
using System.Data.Common;

namespace MarcinWojczal.OrmSurvey.Dapper
{
    public abstract class SurveyMethods<T> : SurveyMethodsBase, IDataAccessMethods where T : DbConnection
    {
        private readonly SurveyDbContext<T> _context;
        internal SurveyMethods(Func<T> createConnection)
        {
            _context = new SurveyDbContext<T>(createConnection);
        }

        public void SelectOrderById(int orderId)
        {
            using var context = _context.CreateConnection();
            var order = context.QueryFirstOrDefault<Order>(Queries.SelectOrderById, new { orderId });
        }

        public void SelectOrderWithDetailsAndEmployeeById(int orderId)
        {
            using var context = _context.CreateConnection();
            var order = context.QueryFirstOrDefault<Order>(Queries.SelectOrderWithDetailsAndEmployeeById, new { orderId });
        }

        public void SelectOrders(int numberOfOrders)
        {
            var orderDate = "1998-01-01";
            using var context = _context.CreateConnection();
            var orders = context.Query<Order>(Queries.SelectTopOrders, new { numberOfOrders, orderDate } ).AsList();
        }

        public void SelectOrdersWithDetailsAndEmployee(int numberOfOrders)
        {
            var orderDate = "1998-01-01";
            using var context = _context.CreateConnection();
            var orders = QueryOrdersWithJoins(context, Queries.SelectTopOrdersWithDetailsAndEmployeeWhereOrderDate, new { numberOfOrders, orderDate }).ToList();
        }

        public void InsertOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var context = _context.CreateConnection();
            context.Open();
            using var transaction = context.BeginTransaction();

            if (orders.Count() == 1)
            {
                var order = orders.First();
                var id = context.ExecuteScalar<int>(Queries.InsertOrders, order, transaction);
                foreach(var detail in order.OrderDetails)
                {
                    detail.OrderID = id;
                }
                context.Execute(Queries.InsertOrderDetails, order.OrderDetails, transaction);
                
            }    
            else
            {
                foreach(var order in orders)
                {
                    var id = context.ExecuteScalar<int>(Queries.InsertOrders, order, transaction);
                    foreach (var detail in order.OrderDetails)
                    {
                        detail.OrderID = id;
                    }
                    context.Execute(Queries.InsertOrderDetails, order.OrderDetails, transaction);
                }
                transaction.Commit();
            }
                
        }

        public void SelectAndUpdateOrdersWithDetails(int numberOfOrders)
        {
            List<Order> orders;
            using (var connection = _context.CreateConnection())
            {
                orders = QueryOrdersWithJoins(connection, Queries.SelectTopOrdersWithDetailsAndEmployee, new { numberOfOrders })
                    .ToList();
            }

            ModifyOrders(orders);

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                this.Update(connection, orders);
            }
        }

        public void UpdateOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var context = _context.CreateConnection();
            context.Open();
            Update(context, orders);
        }

        public void SelectAndDeleteOrdersWithDetails(int numberOfOrders)
        {
            List<Order> orders;
            using (var connection = _context.CreateConnection())
            {
                orders = QueryOrdersWithJoins(connection, Queries.SelectTopOrdersWithDetailsAndEmployee, new { numberOfOrders })
                    .ToList();
            }

            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                Delete(connection, orders);
            }
        }

        public void DeleteOrdersWithDetails(IEnumerable<Order> orders)
        {
            using var context = _context.CreateConnection();
            context.Open();
            Delete(context, orders);
        }

        public void Delete(DbConnection connection, IEnumerable<Order> orders)
        {
            using var transaction = connection.BeginTransaction();
            if (orders.Count() == 1)
            {
                connection.Execute(Queries.DeleteOrderWithDetails, new { orderId = orders.First().Id }, transaction);
                transaction.Commit();
            }
            else
            {
                connection.Execute(Queries.DeleteOrdersWithDetails, new { ordersIds = orders.Select(x => x.Id) }, transaction);
                transaction.Commit();
            }
        }

        private IEnumerable<Order> QueryOrdersWithJoins(DbConnection connection, string query, object param)
        {
            var orderDictionary = new Dictionary<int, Order>();
            var employeeDictionary = new Dictionary<int, Employee>();
            var territoryDictionary = new Dictionary<string, Territory>();

            return connection.Query<Order, OrderDetail, Employee, Employee, Territory, Order>(query, (o, od, e, r, t) =>
            {

                if (!orderDictionary.TryGetValue(o.Id, out Order? order))
                {
                    order = o;
                    order.OrderDetails = new List<OrderDetail>();
                    orderDictionary.Add(o.Id, order);
                }

                if(order.OrderDetails.FirstOrDefault(x => x.ProductID == od?.ProductID) == null)
                {
                    order.OrderDetails.Add(od);
                }

                if(e != null)
                {
                    if (!employeeDictionary.TryGetValue(e.Id, out Employee? employee))
                    {
                        employee = e;
                        employeeDictionary.Add(e.Id, employee);
                    }
                    order.Employee = employee;
                }

                if (r != null)
                {
                    if (!employeeDictionary.TryGetValue(r.Id, out Employee? reportTo))
                    {
                        reportTo = r;
                        employeeDictionary.Add(r.Id, reportTo);
                    }
                    order.Employee.ReportsToEmployee = reportTo;
                    order.Employee.ReportsToEmployee.Territories = new List<Territory>();
                }

                if(t != null)
                {
                    if (!territoryDictionary.TryGetValue(t.Id, out Territory? territory))
                    {
                        territory = t;
                        territoryDictionary.Add(t.Id, territory);
                    }

                    if(order.Employee.ReportsToEmployee.Territories.FirstOrDefault(x => x.Id == t.Id) == null)
                    {
                        order.Employee.ReportsToEmployee.Territories.Add(territory);
                    }
                }

                return order;
            }, param).Distinct();
        }

        private void Update(DbConnection connection, IEnumerable<Order> orders)
        {
            using var transaction = connection.BeginTransaction();
            if (orders.Count() == 1)
            {
                var order = orders.First();
                foreach (var details in order.OrderDetails)
                {
                    connection.Execute(Queries.UpdateOrderDetails, new { unitPrice = details.UnitPrice, orderID = details.OrderID, productID = details.ProductID }, transaction);
                }
                connection.Execute(Queries.UpdateOrder, new { shipRegion = order.ShipRegion, orderId = order.Id }, transaction);
                transaction.Commit();
            }
            else
            {
                foreach (var order in orders)
                {
                    foreach (var details in order.OrderDetails)
                    {
                        connection.Execute(Queries.UpdateOrderDetails, new { unitPrice = details.UnitPrice, orderID = details.OrderID, productID = details.ProductID }, transaction);
                    }
                    connection.Execute(Queries.UpdateOrder, new { shipRegion = order.ShipRegion, orderId = order.Id }, transaction);
                }
                transaction.Commit();
            }
        }
    }
}

