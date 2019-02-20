using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class CitiesController
    {

        public CitiesModel Model { get; }

        public DelegateCommand CityAddCommand { get; }

        public DelegateCommand CityDeleteCommand { get; }

        public CitiesController()
        {
            Model = new CitiesModel();
            CityAddCommand = new DelegateCommand(Model.CityToAdd, (_) => Model.AddCity(), e => 0 == 0);
            CityDeleteCommand = new DelegateCommand(Model.SelectedCity, (_) => Model.DeleteCity(), e => 0 == 0);
        }
    }
}
