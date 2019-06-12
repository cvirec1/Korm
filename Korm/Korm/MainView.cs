using Korm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Korm
{
    public partial class mainForm : Form
    {
        private MainViewModel _viewModel;
        public mainForm(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _viewModel.LoadCustomers();
            dgvCustomer.DataSource = _viewModel.Customers;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            _viewModel.LoadOrders();
            dgvCustomer.DataSource = _viewModel.Orders;
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            _viewModel.SaveCustomers();
        }
    }
}
