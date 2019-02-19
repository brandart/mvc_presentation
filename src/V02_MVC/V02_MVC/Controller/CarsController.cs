using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class CarsController 
    {

        public CarsModel Model { get; }


        public DelegateCommand AddCarCommand { get; }

        public DelegateCommand EditCarCommand { get; }

        public DelegateCommand DeleteCarCommand { get; }

        public CarsController()
        {
            Model = new CarsModel();

            AddCarCommand = new DelegateCommand(Model.CarToAdd, (_) => Model.AddCar(), e => Model.CarToAdd.Name != null );
            EditCarCommand = new DelegateCommand(Model, (_) => Model.EditCar(), e => 0 == 0);
            DeleteCarCommand = new DelegateCommand(Model, (_) => Model.DeleteCar(), e => 0 == 0);
        }
    }
}
