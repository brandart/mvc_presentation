using ShopApplicationWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopApplicationWpf.Controller
{
    // ICommandPattern
    class SetNameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MyModel model;

        public SetNameCommand(MyModel model)
        {
            this.model = model;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            model.Name = (string)parameter;
        }
    }
}
