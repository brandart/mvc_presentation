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
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:8080/");

            HttpResponseMessage response = client.GetAsync("2019_02_06_MVC_Backend/rest/workers").Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
                Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
                // Get the response
                var customerJsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Your response data is: " + customerJsonString);

                // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<WorkerDto>>(custome‌​rJsonString);
                // Do something with it
                
                workers = deserialized.ToList<WorkerDto>();
            }
        }

        public void Login(string Name)
        {
            WorkerDto w = workers.Find(x => x.Name == Name);
            if (w != null)
            {
                _isAdmin = true;
                LogedIn = true;
            }
        }

        private void checkName(string name)
        {
            
        }
    }
}
