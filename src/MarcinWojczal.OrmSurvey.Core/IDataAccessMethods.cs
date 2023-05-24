using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.Core
{
    public interface IDataAccessMethods
    {
        void SelectOrderById(int orderId);
        void SelectOrderWithDetailsAndEmployeeById(int orderId);
        void SelectOrders(int numberOfOrders);
        void SelectOrdersWithDetailsAndEmployee(int numberOfOrders);
        void InsertOrdersWithDetails(IEnumerable<Order> orders);
        void SelectAndUpdateOrdersWithDetails(int numberOfOrders);
        void SelectAndDeleteOrdersWithDetails(int numberOfOrders);
        void UpdateOrdersWithDetails(IEnumerable<Order> orders);
        void DeleteOrdersWithDetails(IEnumerable<Order> orders);
    }
}
