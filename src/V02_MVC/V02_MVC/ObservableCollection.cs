using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V02_MVC
{
    class ObservableCollection : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void RaisePropertyChanged(object element)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(
    NotifyCollectionChangedAction.Add, element));
        }
    }
}
