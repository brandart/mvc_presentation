using ShopApplicationWpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopApplicationWpf.Controller
{
    // ICommandPattern
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Func<object, bool> canExecute;
        private Action<object> execute;

        public DelegateCommand(INotifyPropertyChanged model, Action<object> execute, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
            model.PropertyChanged += (_, ea) => CanExecuteChanged?.Invoke(this, new PropertyChangedEventArgs(ea.PropertyName));
        }

        public bool CanExecute(object parameter) => canExecute(parameter);

        public void Execute(object parameter) => execute(parameter);
    }
}
