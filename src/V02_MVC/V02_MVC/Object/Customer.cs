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

        private int _idCustomer;

        public int IdCustomer
        {
            get
            {
                return _idCustomer;
            }
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

        public bool IsFilled
        {
            get
            {
                if(Name == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

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

        public object GetObject()
        {
            var root = new
            {
                name = Name,
                age = Age,
                city = new
                {
                    idCity = City.IdCity
                }
            };
            return root;
        }
    }
}
