using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.DAL;

namespace V02_MVC.Model
{
    class CarsModel: ObservableCollection<Car>
    {
        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get
            {
                return _cars;
            }
        }
        
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

            SelectedCar = new Car();
        }

        public async void AddCar()
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(SelectedCar));
            
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PostAsync("2019_02_06_MVC_Backend/rest/cars", httpContent);

            Cars.Add(SelectedCar);
        }
    }
}
