using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class CarModel: ObservableObject
    {
        public List<CarDto> _cars;

        public RestModel rest;

        public CarModel()
        {
            rest = RestModel.Instance;
            init();
        }

        public async void init()
        {
            _cars = await rest.GetCars();
        }

        public void AddCar(string name)
        {

        }
    }
}
