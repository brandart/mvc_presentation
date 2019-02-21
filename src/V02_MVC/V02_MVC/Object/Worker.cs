using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    public class Worker: ObservableObject
    {
        private int _idWorker;

        public int IdWorker
        {
            get
            {
                return _idWorker;
            }
            set
            {
                if(_idWorker != value)
                {
                    _idWorker = value;
                    RaisePropertyChanged("IdWorker");
                }
            }
        }
        private bool _admin;
        public bool Admin
        {
            get
            {
                return _admin;
            }
            set
            {
                if(_admin != value)
                {
                    _admin = value;
                    RaisePropertyChanged("Admin");
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
        public object GetObject()
        {
            int IsAdmin = 0;
            if (Admin)
            {
                IsAdmin = 1;
            }
            var root = new
            {
                name = Name,
                age = Age,
                admin = IsAdmin,
                city = new
                {
                    idCity = City.IdCity
                }
            };
            return root;
        }
    }
}
