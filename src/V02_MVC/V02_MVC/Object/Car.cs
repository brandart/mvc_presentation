using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class Car: ObservableObject
    {
        // TODO implement notifychanged methods
        private int _idCar;

        [JsonIgnore]
        public int IdCar
        {
            get
            {
                return _idCar;
            }
            set
            {
                if(_idCar != value)
                {
                    _idCar = value;
                    RaisePropertyChanged("IdCar");
                }
            }
        }

        private string _description;
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        private string _name;
        [JsonProperty("name")]
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
        private double _price;
        [JsonProperty("price")]
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if(_price != value)
                {
                    _price = value;
                    RaisePropertyChanged("Price");
                }
            }
        }
    }
}
