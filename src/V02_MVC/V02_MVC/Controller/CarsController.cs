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

        public CarsController()
        {
            Model = new CarsModel();

            AddCarCommand = new DelegateCommand(Model.SelectedCar, (_) => Model.AddCar(), e => Model.SelectedCar.Name != null );
        }
    }
}
