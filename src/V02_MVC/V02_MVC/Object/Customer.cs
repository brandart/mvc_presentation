using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Object
{
    class Customer: ObservableObject
    {
        [JsonIgnore]
        public int TempIdCustomer;
        private int _idCustomer;
        public int IdCustomer
        {
            set
            {
                if(_idCustomer != value)
                {
                    _idCustomer = value;
                    RaisePropertyChanged("IdCustomer");
                }
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
                if(_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if(_age != value)
                {
                    _age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        private City _city;
        public City City
        {
            get
            {
                return _city;
            }
            set
            {
                if(_city != value)
                {
                    _city = value;
                    RaisePropertyChanged("City");
                }
            }
        }
    }
}
