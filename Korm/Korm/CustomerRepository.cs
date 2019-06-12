using Korm.Model;
using Kros.KORM.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korm.Data
{
    /// <summary>
    /// Works with customers data table.
    /// </summary>
    public class CustomerRepository
    {
        private KormDatabase _database = new KormDatabase();
        private IDbSet<CustomerModel> _customerModels;
        /// <summary>
        /// Get all customer records.
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetCustomers()
        {
            _customerModels = _database.GetAllData<CustomerModel>();
            return _database.GetAllData<CustomerModel>().ToList();
        }

        public void UpdateData(IEnumerable<CustomerModel> dataForUpdate)
        {
            //IDbSet<CustomerModel> customersInDb = _database.GetAllData<CustomerModel>();

            foreach (CustomerModel customer in dataForUpdate)
            {
                _customerModels.Edit(customer);
                //customersInDb.Edit(customer);
            }
            _customerModels.BulkUpdate();
            //customersInDb.BulkUpdate();
        } 

    }
}
