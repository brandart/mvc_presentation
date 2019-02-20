using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    public class City: ObservableObject
    {

        [JsonIgnore]
        public int TempIdCity
        {
            get
            {
                return _idCity;
            }
        }

        [JsonIgnore]
        public bool IsFilled
        {
            get
            {
                if (TempIdCity == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private int _idCity;

        [JsonProperty("idCity")]
        public int IdCity
        {
            set
            {
                if(_idCity != value)
                {
                    _idCity = value;
                    RaisePropertyChanged("IdCity");
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

        private int _plz;
        [JsonProperty("plz")]
        public int Plz
        {
            get
            {
                return _plz;
            }
            set
            {
                if(_plz != value)
                {
                    _plz = value;
                    RaisePropertyChanged("Plz");
                }
            }
        }


    }
}
