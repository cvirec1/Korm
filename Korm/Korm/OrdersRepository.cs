using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korm.Data
{
    public class OrdersRepository
    {

        private KormDatabase _database = new KormDatabase();

        /// <summary>
        /// Get all customer records.
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetOrders() => _database.GetAllData<OrderModel>().Take(5).ToList();

        public IEnumerable GetOrdersViaJoin()
        {
            return _database.GetAllDataViaJoin<OrderModel>(
                "Orders.*, Customers.CompanyName AS Company",
                "Orders LEFT JOIN Customers ON Orders.CUstomerID = Customers.CustomerID")
                .ToList();
        }
    }
}
