using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class CarController
    {
        public CarModel Model { get; }

        public CarController()
        {
            Model = new CarModel();
        }
    }
}
