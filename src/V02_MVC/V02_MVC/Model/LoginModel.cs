using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.DAL;

namespace V02_MVC.Model
{
    class LoginModel: ObservableObject
    {

        private List<Worker> _workers;
        public List<Worker> Workers
        {
            get
            {
                return _workers;
            }
        }

        private MyDAL dal;

        private bool _logedIn;

        public bool LogedIn
        {
            get
            {
                return _logedIn;
            }
            set
            {
                _logedIn = value;
                RaisePropertyChanged("LogedIn");

            }
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private bool _isAdmin;
        
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
        }

        private Worker _logedInWorker;

        public Worker LogedInWorker
        {
            get
            {
                return _logedInWorker;
            }
        }

        public LoginModel()
        {
            LogedIn = false;
            initData();
        }

        private async void initData()
        {
            dal = MyDAL.Instance;
            string JsonWorker =  await dal.GetAsync("2019_02_06_MVC_Backend/rest/workers");
            var deserialized = JsonConvert.DeserializeObject<IEnumerable<Worker>>(JsonWorker);
            // Do something with it

            _workers = deserialized.ToList<Worker>();

        }

        public void Login(string Name)
        {
            Worker w = _workers.Find(x => x.Name == Name);
            if (w != null)
            {
                _logedInWorker = w;
                _isAdmin = w.Admin;
                LogedIn = true;
            }
        }
    }
}
