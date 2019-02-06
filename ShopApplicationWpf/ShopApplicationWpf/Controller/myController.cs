using ShopApplicationWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplicationWpf.Controller
{
    class myController
    {
        public myModel model { get; private set; } 
        

        public myController()
        {
            model = new myModel();
        }

        public void setName(String s)
        {
            model.Name = s;
        }

    }
}
