using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class CustomersController
    {
        public CustomersModel Model { get; }
        public DelegateCommand AddCustomerCommand { get; }

        public DelegateCommand EditCustomerCommand { get; }

        public DelegateCommand DeleteCustomerCommand { get; }

        public CustomersController()
        {
            Model = new CustomersModel();

            AddCustomerCommand = new DelegateCommand(Model.CustomerToAdd, (_) => Model.AddCustomer(), e => 0 == 0);
            EditCustomerCommand = new DelegateCommand(Model.SelectedCustomer, (_) => Model.EditCustomer(), e => 0 == 0);
            DeleteCustomerCommand = new DelegateCommand(Model.SelectedCustomer, (_) => Model.DeleteCustomer(), e => 0 == 0);
        }
    }
}
