using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V02_MVC.Model;

namespace V02_MVC.Controller
{
    class LoginController
    {
        public LoginModel Model { get;}

        public DelegateCommand LoginCommand { get; }

        public LoginController()
        {
            Model = new LoginModel();
            LoginCommand = new DelegateCommand(Model, username => Model.Login((string)username) ,(_) => !Model.LogedIn);
        }
    }
}
