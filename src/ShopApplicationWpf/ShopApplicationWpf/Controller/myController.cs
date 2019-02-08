using ShopApplicationWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplicationWpf.Controller
{
    class MyController: ObservableObject
    {
        // == immutable 
        public MyModel Model { get; }

        public DelegateCommand SetNameCommand { get; }


        public MyController()
        {
            Model = new MyModel();
            SetNameCommand = new DelegateCommand(Model, name => Model.Name = (string)name, (_) => Model.Name != "disabled");
        }

        

    }
}
