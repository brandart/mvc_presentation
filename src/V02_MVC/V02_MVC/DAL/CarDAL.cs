using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class CarDAL: ObservableObject
    {
        public List<Car> _cars;

        public RestModel rest;

        public CarDAL()
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
