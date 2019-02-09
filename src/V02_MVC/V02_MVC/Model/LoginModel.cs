using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class LoginModel: ObservableObject
    {

        List<WorkerDto> workers;

        private RestModel rest;

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

        public LoginModel()
        {
            LogedIn = false;
            initAsync();
        }

        private async Task initAsync()
        {
            rest = RestModel.Instance;
            workers =  await rest.GetWorkers();
        }

        public void Login(string Name)
        {
            WorkerDto w = workers.Find(x => x.Name == Name);
            if (w != null)
            {
                _isAdmin = true;
                LogedIn = w.Admin;
            }
        }
    }
}
