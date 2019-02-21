using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class WorkersController
    {
        public WorkersModel Model { get; private set; }

        public DelegateCommand AddWorkerCommand { get; }
        public DelegateCommand DeleteWorkerCommand { get; }
        public DelegateCommand EditWorkerCommand { get;  }

        public WorkersController()
        {
            Model = new WorkersModel();

            AddWorkerCommand = new DelegateCommand(Model.WorkerToAdd, (_) => Model.AddWorker(), e => 0 == 0);
            DeleteWorkerCommand = new DelegateCommand(Model.SelectedWorker, (_) => Model.DeleteWorker(), e => 0 == 0);
            EditWorkerCommand = new DelegateCommand(Model.SelectedWorker, (_) => Model.EditWorker(), e => 0 == 0); 
        }
    }
}
