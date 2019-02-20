using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.DAL;

namespace V02_MVC.Model
{
    class CitiesModel: MyObservableCollection<City>
    {
        private MyDAL Dal;
        public ObservableCollection<City> Cities { get; private set; }

        public City CityToAdd { get; set; }

        private readonly string RestUrl = "2019_02_06_MVC_Backend/rest/cities/";

        
        private City _selectedCity;
        public City SelectedCity
        {
            get
            {
                return _selectedCity;
            }
            set
            {
                _selectedCity = value;
                RaisePropertyChanged("SelectedCity");
            }
        }

        public CitiesModel()
        {
            Dal = MyDAL.Instance;

            initData();
        }

        private async void initData()
        {
            string JsonCities = await Dal.GetAsync(RestUrl);

            var deserialized = JsonConvert.DeserializeObject<IEnumerable<City>>(JsonCities);

            List<City> temp = deserialized.ToList<City>();
            Cities = new ObservableCollection<City>(temp);

            CityToAdd = new City();

             SelectedCity = new City(); 
        }

        public async void AddCity()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(CityToAdd.GetObject()));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PostAsync(RestUrl, httpContent); 
            if (response.IsSuccessStatusCode)
            {
                Cities.Add(CityToAdd);
                RaisePropertyChanged("AddCity");
                CityToAdd = new City();
            }else
            {
                RaisePropertyChanged("AddCityUn");
            }
        }

        public async void DeleteCity()
        {
            var response = await Dal.DeleteAsync(RestUrl + _selectedCity.IdCity);
            
           
            if (response.IsSuccessStatusCode)
            {
                Cities.Remove(_selectedCity);
                RaisePropertyChanged("DeleteCar");
                SelectedCity = new City();
            } else
            {
                RaisePropertyChanged("DeleteCarUnsuccessful");
            }
        }

        public async void EditCity()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(_selectedCity.GetObject()));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PutAsync(RestUrl + _selectedCity.IdCity, httpContent);
            if (response.IsSuccessStatusCode)
            {
                RaisePropertyChanged("EditCity");
            }
            else
            {
                RaisePropertyChanged("EditCityUn");
            }
        }

    }
}
