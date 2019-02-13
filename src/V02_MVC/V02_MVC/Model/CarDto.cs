using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class CarDto
    {
        public int IdCar { get; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
