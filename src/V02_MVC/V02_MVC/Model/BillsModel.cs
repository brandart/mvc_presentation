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
    class BillsModel: MyObservableCollection<Bill>
    {
        public ObservableCollection<Bill> Bills { get; private set; }
        public ObservableCollection<Customer> Customers { get; private set; }
        public ObservableCollection<Car> Cars { get; private set; }

        private readonly string RestUrl = "2019_02_06_MVC_Backend/rest/bills/";
        private readonly string RestUrlCustomers = "2019_02_06_MVC_Backend/rest/customers/";
        private readonly string RestUrlCars = "2019_02_06_MVC_Backend/rest/cars/";

        public Bill BillToAdd { get; set; }

        private Bill _selectedBill;
        public Bill SelectedBill
        {
            get
            {
                return _selectedBill;
            }
            set
            {
                _selectedBill = value;
                RaisePropertyChanged("SelectedBill");
            }
        
        }
        private Car _topCar;
        public Car TopCar
        {
            get
            {
                return _topCar;
            }
            set
            {
                _topCar = value;
                RaisePropertyChanged("TopCar");
            }
        }

        private Customer _topCustomer;
        public Customer TopCustomer
        {
            get
            {
                return _topCustomer;
            }
            set
            {
                _topCustomer = value;
                RaisePropertyChanged("TopCustomer");
            }
        }

        private MyDAL Dal;
        public double Revenue { get; private set; }
        public BillsModel()
        {
            Dal = MyDAL.Instance;
            InitData();
            this.PropertyChanged += Model_Calculate;
        }

        private void Model_Calculate(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Calculate")
            {
                CalculateTopCustomer();
                CalculateTopCar();
            }
        }

        private async void InitData()
        {
            // get workers
            string JsonBills = await Dal.GetAsync(RestUrl);
            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Bill>>(JsonBills);
            List<Bill> temp = deserialized.ToList<Bill>();
            Bills = new ObservableCollection<Bill>(temp);

            // get customers
            string JsonCustomers = await Dal.GetAsync(RestUrlCustomers);
            var deserialized2 = JsonConvert.DeserializeObject<IEnumerable<Customer>>(JsonCustomers);
            List<Customer> temp2 = deserialized2.ToList<Customer>();
            Customers = new ObservableCollection<Customer>(temp2);

            // get cars
            string JsonCars = await Dal.GetAsync(RestUrlCars);
            var deserialized3 = JsonConvert.DeserializeObject<IEnumerable<Car>>(JsonCars);
            List<Car> temp3 = deserialized3.ToList<Car>();
            Cars = new ObservableCollection<Car>(temp3);
            Revenue = 0.0;
            CalculateRevenue();
            _topCustomer = new Customer();
            _topCar = new Car();
            CalculateTopCustomer();
            CalculateTopCar();

            BillToAdd = new Bill();
            _selectedBill = new Bill();
        }

        private void CalculateRevenue()
        {
            Revenue = 0.0;
            foreach(var b in Bills)
            {
                var t = b.Car.Price - b.Discount;
                Revenue += t;
            }
            RaisePropertyChanged("Revenue");
        }

        public async void AddBill()
        {
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(BillToAdd.GetObject()));
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await Dal.PostAsync(RestUrl, httpContent);
            if (response.IsSuccessStatusCode)
            {
                Bills.Add(BillToAdd);
                RaisePropertyChanged("AddBill");
                Revenue += BillToAdd.Car.Price - BillToAdd.Discount;
                RaisePropertyChanged("Revenue");
                RaisePropertyChanged("Caluclate");
                BillToAdd = new Bill();
                RaisePropertyChanged("BillToAdd");

            }
        }
        private void CalculateTopCar()
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (var c in Cars)
            {
                map.Add(c.DisplayString, 0);
            }
            foreach (var b in Bills)
            {
                map[b.Car.DisplayString]++;
            }
            var s = map.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var t = Cars.Where(x => x.DisplayString == s);
            TopCar = t.ToList().First();
        }

        private void CalculateTopCustomer()
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            
            foreach(var c in Customers)
            {
                map.Add(c.Name, 0);
            }
            foreach(var b in Bills)
            {
                map[b.Customer.Name]++;
            }
            var s = map.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var t = Customers.Where(x => x.Name == s);
            TopCustomer = t.ToList().First();
        }


        public async void DeleteBill()
        {
            var response = await Dal.DeleteAsync(RestUrl + _selectedBill.IdBill);
            if (response.IsSuccessStatusCode)
            {
                Revenue -= _selectedBill.Car.Price - _selectedBill.Discount;
                RaisePropertyChanged("Revenue");
                Bills.Remove(_selectedBill);
                RaisePropertyChanged("Calculate");
                RaisePropertyChanged("DeleteBill");

                SelectedBill = new Bill();
            }
        }
    }
}
