using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.DAL;

namespace V02_MVC.Model
{
    class CarsModel: MyObservableCollection<Car>
    {
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get
            {
                return _cars;
            }
        }
        
        public Car CarToAdd { get; set; }

        public Car SelectedCar { get; set; }

        private MyDAL Dal;

        public CarsModel()
        {
            Dal = MyDAL.Instance;

            InitData();
        }

        private async void InitData()
        {
            string JsonCars = await Dal.GetAsync("2019_02_06_MVC_Backend/rest/cars");

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Car>>(JsonCars);
            // Do something with it

            List<Car> temp = deserialized.ToList<Car>();
            _cars = new ObservableCollection<Car>(temp);

            CarToAdd = new Car();
            SelectedCar = new Car();
        }

        public async void AddCar()
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(CarToAdd));



            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PostAsync("2019_02_06_MVC_Backend/rest/cars", httpContent);
            if (response.IsSuccessStatusCode)
            {
                Cars.Add(CarToAdd);
                RaisePropertyChanged("AddCar");
                CarToAdd = new Car();
            }
        }

        public void DeleteCar()
        {

        }
    }
}
