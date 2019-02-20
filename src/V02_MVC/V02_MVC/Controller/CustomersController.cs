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

        public CustomersController()
        {
            Model = new CustomersModel();

            AddCustomerCommand = new DelegateCommand(Model.CustomerToAdd, (_) => Model.AddCustomer(), e => 0 == 0);
        }
    }
}
