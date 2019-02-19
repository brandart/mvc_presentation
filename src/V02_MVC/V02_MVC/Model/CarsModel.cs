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

        private Car _selectedCar;
        public Car SelectedCar
        {
            get
            {
                return _selectedCar;
            }

            set
            {
                _selectedCar = value;
                RaisePropertyChanged("SelectedCar");
            }
        }

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
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(CarToAdd));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PostAsync("2019_02_06_MVC_Backend/rest/cars", httpContent);
            if (response.IsSuccessStatusCode)
            {
                Cars.Add(CarToAdd);
                RaisePropertyChanged("AddCar");
                CarToAdd = new Car();
            }
        }

        public async void DeleteCar()
        {
            var response = await Dal.DeleteAsync("2019_02_06_MVC_Backend/rest/cars/" + SelectedCar.TempIdCar);
            if (response.IsSuccessStatusCode)
            {
                Cars.Remove(SelectedCar);
                RaisePropertyChanged("DeleteCar");
                SelectedCar = new Car();
            }
        }

        public async void EditCar()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(SelectedCar));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PutAsync("2019_02_06_MVC_Backend/rest/cars/" + SelectedCar.TempIdCar, httpContent);
            if (response.IsSuccessStatusCode)
            {
                RaisePropertyChanged("EditCar");
                SelectedCar = new Car();
            }
        }
    }
}
