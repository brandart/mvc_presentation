using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplicationWpf.Model
{
    class MyModel: ObservableObject
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name ?? "Unknown";
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


    }
}
