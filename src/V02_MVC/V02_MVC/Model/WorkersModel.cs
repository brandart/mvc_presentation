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
    class WorkersModel : MyObservableCollection<Worker>
    {
        public ObservableCollection<Worker> Workers { get; private set; }
        public ObservableCollection<City> Cities { get; private set; }
        private readonly string RestUrl = "2019_02_06_MVC_Backend/rest/workers/";
        private readonly string RestUrlCities = "2019_02_06_MVC_Backend/rest/cities/";

        public Worker WorkerToAdd { get; set; }

        private MyDAL Dal;

        private Worker _selectedWorker;
        public Worker SelectedWorker
        {
            get
            {
                return _selectedWorker;
            }
            set
            {
                _selectedWorker = value;
                RaisePropertyChanged("SelectedWorker");
            }
        }

        public WorkersModel()
        {
            Dal = MyDAL.Instance;
            initData();
        }

        public async void initData()
        {
            // get workers
            string JsonWorkers = await Dal.GetAsync(RestUrl);
            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Worker>>(JsonWorkers);
            List<Worker> temp = deserialized.ToList<Worker>();
            Workers = new ObservableCollection<Worker>(temp);

            // get cities
            string JsonCities = await Dal.GetAsync(RestUrlCities);
            var deserialized2 = JsonConvert.DeserializeObject<IEnumerable<City>>(JsonCities);
            List<City> temp2 = deserialized2.ToList<City>();
            Cities = new ObservableCollection<City>(temp2);

            WorkerToAdd = new Worker();
            _selectedWorker = new Worker();
        }

        public async void AddWorker()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(WorkerToAdd.GetObject()));
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await Dal.PostAsync(RestUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                Workers.Add(WorkerToAdd);
                RaisePropertyChanged("AddWorker");
                WorkerToAdd = new Worker();
                RaisePropertyChanged("WorkerToAdd");
            }
        }

        public async void DeleteWorker()
        {
            var response = await Dal.DeleteAsync(RestUrl + _selectedWorker.IdWorker);
            if (response.IsSuccessStatusCode)
            {
                Workers.Remove(_selectedWorker);
                RaisePropertyChanged("DeleteWorker");
                SelectedWorker = new Worker();
            }
        }

        public async void EditWorker()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(_selectedWorker.GetObject()));
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await Dal.PutAsync(RestUrl + _selectedWorker.IdWorker, httpContent);
            if (response.IsSuccessStatusCode)
            {
                RaisePropertyChanged("EditWorker");
            }
        }
    }
}
