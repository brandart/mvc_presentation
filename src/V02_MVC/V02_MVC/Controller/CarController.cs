using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class CarController: ObservableCollection 
    {

        // aufbau der benutzer
        public CarDAL Model { get; }

        public List<CarDto> Cars;

        public DelegateCommand AddCarCommand { get; }

        public CarController()
        {
            Model = new CarDAL();

            AddCarCommand = new DelegateCommand(Model, (car) => Model.AddCar(((CarDto)car).Name), e => true);
        }
    }
}
