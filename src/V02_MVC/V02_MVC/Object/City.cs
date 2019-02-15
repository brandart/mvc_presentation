using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    public class City: ObservableObject
    {
        private int _idCity;
        public int IdCity
        {
            get
            {
                return _idCity;
            }
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
