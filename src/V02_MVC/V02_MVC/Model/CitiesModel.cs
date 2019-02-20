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
    class CitiesModel: MyObservableCollection<City>
    {
        private MyDAL Dal;
        public ObservableCollection<City> Cities
        {
            get
            {
                return _cities;
            }
        }

        private ObservableCollection<City> _cities;

        public City CityToAdd { get; set; }

        private readonly string RestUrl = "2019_02_06_MVC_Backend/rest/cities/";

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
            _cities = new ObservableCollection<City>(temp);

            CityToAdd = new City();

            // SelectedCity = new Car(); 
        }

        public async void AddCity()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(CityToAdd));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await Dal.PostAsync(RestUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                Cities.Add(CityToAdd);
                RaisePropertyChanged("AddCity");
                CityToAdd = new City();
            }
        }

    }
}
