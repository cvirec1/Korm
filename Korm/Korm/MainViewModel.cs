using Korm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korm.Data
{
    public class MainViewModel
    {
        #region private fields
        private CustomerRepository _customerRepository;
        private OrdersRepository _ordersRepository;
        #endregion

        #region constructors
        public MainViewModel(CustomerRepository customerRepository, OrdersRepository ordersRepository)
        {
            _customerRepository = customerRepository;
            _ordersRepository = ordersRepository;
        }
        #endregion

        #region properties
        public BindingList<CustomerModel> Customers { get; set; }
        #endregion

        #region Loading customers
        public void LoadCustomers()
        {
            Customers = new BindingList<CustomerModel>((List<CustomerModel>)_customerRepository.GetCustomers());
        }


        #endregion
        #region save
        internal void SaveCustomers()
        {
            _customerRepository.UpdateData(Customers);
        }
        #endregion

        #region properties
        public BindingList<OrderModel> Orders { get; set; }
        #endregion

        #region Loading orders
        public void LoadOrders()
        {
            Orders = new BindingList<OrderModel>((List<OrderModel>)_ordersRepository.GetOrdersViaJoin());
        }
        #endregion
    }
}
