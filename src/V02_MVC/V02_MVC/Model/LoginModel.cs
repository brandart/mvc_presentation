using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC.Model
{
    class LoginModel: ObservableObject
    {
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

        public LoginModel()
        {

        }
    }
}
