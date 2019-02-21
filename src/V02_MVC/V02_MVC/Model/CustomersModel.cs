using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.DAL;
using V02_MVC.Object;

namespace V02_MVC.Model
{
    class CustomersModel: MyObservableCollection<Customer>
    {
        private MyDAL Dal;
        private readonly string RestUrl = "2019_02_06_MVC_Backend/rest/customers/";
        private readonly string RestUrlCities = "2019_02_06_MVC_Backend/rest/cities/";
        public ObservableCollection<Customer> Customers { get; private set; }

        public ObservableCollection<City> Cities { get; private set; }

        public Customer CustomerToAdd { get; set; }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            } 
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged("SelectedCustomer");
            }
        }

        public CustomersModel()
        {
            Dal = MyDAL.Instance;

            initData();
        }

        private async void initData()
        {
            // get customers
            string JsonCustomers = await Dal.GetAsync(RestUrl);
            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Customer>>(JsonCustomers);
            List<Customer> temp = deserialized.ToList<Customer>();
            Customers = new ObservableCollection<Customer>(temp);

            // get cities
            string JsonCities = await Dal.GetAsync(RestUrlCities);
            var deserializedCities = JsonConvert.DeserializeObject<IEnumerable<City>>(JsonCities);
            List<City> temp2 = deserializedCities.ToList<City>();
            Cities = new ObservableCollection<City>(temp2);

            CustomerToAdd = new Customer();
            _selectedCustomer = new Customer();
        }

        public async void AddCustomer()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(CustomerToAdd.GetObject()));
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await Dal.PostAsync(RestUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                Customers.Add(CustomerToAdd);
                RaisePropertyChanged("AddCustomer");
            }
        }

        public async void EditCustomer()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(_selectedCustomer.GetObject()));
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await Dal.PutAsync(RestUrl + _selectedCustomer.IdCustomer, httpContent);
            if (response.IsSuccessStatusCode)
            {
                RaisePropertyChanged("EditCustomer");
            }
        }

        public async void DeleteCustomer()
        {
            var response = await Dal.DeleteAsync(RestUrl + _selectedCustomer.IdCustomer);
            if (response.IsSuccessStatusCode)
            {
                Customers.Remove(_selectedCustomer);
                RaisePropertyChanged("DeleteCustomer");
                _selectedCustomer = new Customer();
            } else
            {
                RaisePropertyChanged("DeleteCustomerUn");
            }

        }
    }
}
