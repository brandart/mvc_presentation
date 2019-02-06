using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplicationWpf.Model
{
    class myModel: ObservableObject
    {
        private String _name;
        public String Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    return "Unknown";
                return _name;
            }
            set
            {
                _name = value;
                onPropertyChanged("Name");
            }
        }


    }
}
