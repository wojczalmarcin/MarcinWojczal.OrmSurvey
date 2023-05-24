using MarcinWojczal.OrmSurvey.Models;

namespace MarcinWojczal.OrmSurvey.Core
{
    public class SurveyMethodsBase
    {
        public static void ModifyOrders(IEnumerable<Order> orders)
        {
            var random = new Random();
            var randomShipRegion = $"{random.Next()}";
            var unitPrice = random.Next(10000);

            foreach (var order in orders) 
            {
                order.ShipRegion = order.ShipRegion != randomShipRegion ? randomShipRegion : randomShipRegion + " 1";
                foreach(var details in order.OrderDetails)
                {
                    details.UnitPrice = details.UnitPrice != unitPrice ? unitPrice : unitPrice + 1;
                }
            }
        }
    }
}
