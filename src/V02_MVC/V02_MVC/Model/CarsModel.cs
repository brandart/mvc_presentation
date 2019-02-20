﻿using Newtonsoft.Json;
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
        private readonly string RestUrl = "2019_02_06_MVC_Backend/rest/cars/";
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
                if(_selectedCar != value)
                {
                    _selectedCar = value;
                    RaisePropertyChanged("SelectedCar");
                }
                
                
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
            string JsonCars = await Dal.GetAsync(RestUrl);

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Car>>(JsonCars);

            List<Car> temp = deserialized.ToList<Car>();
            _cars = new ObservableCollection<Car>(temp);

            CarToAdd = new Car();
            SelectedCar = new Car();
        }

        public async void AddCar()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(CarToAdd));
            

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PostAsync(RestUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                Cars.Add(CarToAdd);
                RaisePropertyChanged("AddCar");
                CarToAdd = new Car();
            }
        }

        public async void DeleteCar()
        {
            var response = await Dal.DeleteAsync(RestUrl + _selectedCar.TempIdCar);
            if (response.IsSuccessStatusCode)
            {
                Cars.Remove(_selectedCar);
                RaisePropertyChanged("DeleteCar");
                SelectedCar = new Car();
            }
        }

        public async void EditCar()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(_selectedCar));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PutAsync(RestUrl + _selectedCar.TempIdCar, httpContent);
            if (response.IsSuccessStatusCode)
            {
                RaisePropertyChanged("EditCar");
            }
        }
    }
}
