using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class BillsController
    {
        public BillsModel Model { get; private set; }

        public DelegateCommand AddBillCommand { get; }
        public DelegateCommand EditBillCommand { get; }
        public DelegateCommand DeleteBillCommand { get; }

        public BillsController()
        {
            Model = new BillsModel();
            AddBillCommand = new DelegateCommand(Model.BillToAdd, (_) => Model.AddBill(), e => 0 == 0);
            DeleteBillCommand = new DelegateCommand(Model.SelectedBill, (_) => Model.DeleteBill(), e => 0 == 0);
        }
    }
}
